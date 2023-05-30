
Imports System.Numerics

Public Structure Triangle_Calc
    Dim A As Integer
    Dim B As Integer
    Dim C As Integer
End Structure

Public Structure Triangle
    Dim A As Point
    Dim B As Point
    Dim C As Point
End Structure

Public Class DelaunayTriangulation

    Public Shared Function Triangulate(Points As List(Of Point)) As List(Of Triangle)

        Dim MaxVertices As Integer = Points.Count 'Set these as applicable
        Dim MaxTriangles As Integer = MaxVertices * 3
        Dim Vertex(MaxVertices + 2) As Vector3 'Our points, the extra 2 are for the 3 points of the supertriangle
        Dim VertexCount As Integer = -1
        Dim Triangles(MaxTriangles - 1) As Triangle_Calc 'Our Created Triangles, -1 because it is zero based
        Dim TriangleCount As Integer = -1
        Dim Edges(1, -1) As Integer

        For Each p As Point In Points
            AddVertex(VertexCount, Vertex, p.X, p.Y, 0)
        Next

        CalculateTriangles(MaxVertices, MaxTriangles, Vertex, VertexCount, Triangles, TriangleCount, Edges)

        Dim Output As New List(Of Triangle)

        For i = 0 To Triangles.Length - 1
            Dim Tri As Triangle = ConvertToDrawingTriangle(Vertex, Triangles(i))

            ' Check if all three points of the triangle exist in the Points list
            Dim pointAExists As Boolean = Points.Contains(Tri.A)
            Dim pointBExists As Boolean = Points.Contains(Tri.B)
            Dim pointCExists As Boolean = Points.Contains(Tri.C)

            ' If all three points exist, add the triangle to the Output list
            If pointAExists AndAlso pointBExists AndAlso pointCExists Then
                Output.Add(Tri)
            End If
        Next


        Return Output

    End Function
    Public Shared Function ConvertToDrawingTriangle(ByRef Vertex() As Vector3, ByVal calcTriangle As Triangle_Calc) As Triangle
        Dim drawingTriangle As New Triangle()

        drawingTriangle.A = New Point(Vertex(calcTriangle.A).X, Vertex(calcTriangle.A).Y)
        drawingTriangle.B = New Point(Vertex(calcTriangle.B).X, Vertex(calcTriangle.B).Y)
        drawingTriangle.C = New Point(Vertex(calcTriangle.C).X, Vertex(calcTriangle.C).Y)

        Return drawingTriangle
    End Function
    Public Shared Sub AddVertex(ByRef VertexCount As Integer, ByRef Vertex() As Vector3, ByVal x As Single, ByVal y As Single, ByVal z As Single)
        VertexCount += 1
        Vertex(VertexCount).X = x
        Vertex(VertexCount).Y = y
        Vertex(VertexCount).Z = z
    End Sub

    Public Shared Sub CalculateTriangles(ByRef MaxVerticies As Integer, ByRef MaxTriangles As Integer, ByRef Vertex() As Vector3, ByRef VertexCount As Integer, ByRef Triangles() As Triangle_Calc, ByRef TriangleCount As Integer, ByRef Edges(,) As Integer) 'These triangles are arranged in clockwise order.
        TriangleCount = -1
        ReDim Edges(1, MaxTriangles * 3)
        Dim Nedge As Integer
        Dim j As Integer
        Dim k As Integer
        Dim inc As Boolean

        'For Super Triangle
        Dim xmin As Single = Vertex(0).X 'This is to allow calculation of the bounding triangle
        Dim xmax As Single = xmin
        Dim ymin As Single = Vertex(0).Y
        Dim ymax As Single = ymin

        For i = 1 To VertexCount
            If Vertex(i).X < xmin Then xmin = Vertex(i).X
            If Vertex(i).X > xmax Then xmax = Vertex(i).X
            If Vertex(i).Y < ymin Then ymin = Vertex(i).Y
            If Vertex(i).Y > ymax Then ymax = Vertex(i).Y
        Next
        Dim dx As Single = xmax - xmin
        Dim dy As Single = ymax - ymin
        Dim dmax As Single = dy
        If dx > dy Then dmax = dx
        Dim xmid As Single = (xmax + xmin) / 2
        Dim ymid As Single = (ymax + ymin) / 2

        'Set up the supertriangle. This is a triangle which encompasses all the sample points.
        'The supertriangle coordinates are added to the end of the vertex list. The supertriangle is the first triangle in the triangle list.
        Vertex(VertexCount + 1).X = xmid - 2 * dmax
        Vertex(VertexCount + 1).Y = ymid - dmax
        Vertex(VertexCount + 2).X = xmid
        Vertex(VertexCount + 2).Y = ymid + 2 * dmax
        Vertex(VertexCount + 3).X = xmid + 2 * dmax
        Vertex(VertexCount + 3).Y = ymid - dmax
        Triangles(0).A = VertexCount + 1
        Triangles(0).B = VertexCount + 2
        Triangles(0).C = VertexCount + 3
        Dim ntri As Integer = 0

        'Include each point one at a time into the existing mesh
        For i = 0 To VertexCount
            Nedge = 0
            'Set up the edge buffer.
            'If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the three edges of that triangle are added to the edge buffer.
            j = -1
            Do
                j += 1
                inc = InCircle(Vertex(i).X, Vertex(i).Y, Vertex(Triangles(j).A).X, Vertex(Triangles(j).A).Y, Vertex(Triangles(j).B).X, Vertex(Triangles(j).B).Y, Vertex(Triangles(j).C).X, Vertex(Triangles(j).C).Y)
                If inc Then
                    If Nedge + 2 > UBound(Edges, 2) Or j > MaxTriangles Then Exit Sub 'Out of range
                    Edges(0, Nedge) = Triangles(j).A
                    Edges(1, Nedge) = Triangles(j).B
                    Edges(0, Nedge + 1) = Triangles(j).B
                    Edges(1, Nedge + 1) = Triangles(j).C
                    Edges(0, Nedge + 2) = Triangles(j).C
                    Edges(1, Nedge + 2) = Triangles(j).A
                    Nedge += 3
                    Triangles(j).A = Triangles(ntri).A
                    Triangles(j).B = Triangles(ntri).B
                    Triangles(j).C = Triangles(ntri).C
                    j -= 1
                    ntri -= 1
                End If
            Loop While j < ntri

            'Tag multiple edges
            'Note: if all triangles are specified anticlockwise then all interior edges are opposite pointing in direction.
            If Nedge - 1 > UBound(Edges, 2) Then Exit Sub 'Out of range
            For j = 0 To Nedge - 2
                If Not Edges(0, j) = -1 And Not Edges(1, j) = -1 Then
                    For k = j + 1 To Nedge - 1
                        If Not Edges(0, k) = -1 And Not Edges(1, k) = -1 Then
                            If Edges(0, j) = Edges(1, k) Then
                                If Edges(1, j) = Edges(0, k) Then
                                    Edges(0, j) = -1
                                    Edges(1, j) = -1
                                    Edges(0, k) = -1
                                    Edges(1, k) = -1
                                End If
                            End If
                        End If
                    Next k
                End If
            Next j

            'Form new triangles for the current point, Skipping over any tagged edges.
            'All edges are arranged in clockwise order.
            For j = 0 To Nedge - 1
                If Not Edges(0, j) = -1 And Not Edges(1, j) = -1 Then
                    ntri += 1
                    If j > UBound(Edges, 2) Or ntri > UBound(Triangles) Then Exit Sub 'Out of range
                    Triangles(ntri).A = Edges(0, j)
                    Triangles(ntri).B = Edges(1, j)
                    Triangles(ntri).C = i
                End If
            Next j
        Next


        'Remove triangles with supertriangle vertices. These are triangles which have a vertex number greater than NVERT
        j = -1
        Do
            j += 1
            If Triangles(j).A > VertexCount Or Triangles(j).B > VertexCount Or Triangles(j).C > VertexCount Then
                Triangles(j).A = Triangles(ntri).A
                Triangles(j).B = Triangles(ntri).B
                Triangles(j).C = Triangles(ntri).C
                j -= 1
                ntri -= 1
            End If
        Loop While j < ntri


        'Build Edge list from triangles
        Nedge = -1
        Dim a As Integer
        Dim b As Integer
        Dim c As Integer
        Dim ab As Boolean
        Dim bc As Boolean
        Dim ca As Boolean
        If ntri > -1 Then ReDim Edges(1, (ntri + 1) * 3) 'Just making sure this array is big enough
        For i = 0 To ntri
            ab = True
            bc = True
            ca = True
            a = Triangles(i).A
            b = Triangles(i).B
            c = Triangles(i).C
            For j = 0 To Nedge
                If Edges(0, j) = a And Edges(1, j) = b Then ab = False
                If Edges(0, j) = b And Edges(1, j) = a Then ab = False

                If Edges(0, j) = b And Edges(1, j) = c Then bc = False
                If Edges(0, j) = c And Edges(1, j) = b Then bc = False

                If Edges(0, j) = c And Edges(1, j) = a Then ca = False
                If Edges(0, j) = a And Edges(1, j) = c Then ca = False
            Next
            If ab Then
                Nedge += 1
                Edges(0, Nedge) = a
                Edges(1, Nedge) = b
            End If
            If bc Then
                Nedge += 1
                Edges(0, Nedge) = b
                Edges(1, Nedge) = c
            End If
            If ca Then
                Nedge += 1
                Edges(0, Nedge) = c
                Edges(1, Nedge) = a
            End If
        Next
        ReDim Preserve Edges(1, Nedge)

        TriangleCount = ntri
    End Sub
    Private Shared Function InCircle(ByRef xp As Integer, ByRef yp As Integer, ByRef x1 As Integer, ByRef y1 As Integer, ByRef x2 As Integer, ByRef y2 As Integer, ByRef x3 As Integer, ByRef y3 As Integer) As Boolean
        'Return TRUE if the point (xp,yp) lies inside the circumcircle
        'made up by points (x1,y1) (x2,y2) (x3,y3)
        'The circumcircle centre is returned in (xc,yc) and the radius r
        'NOTE: A point on the edge is inside the circumcircle

        Dim m1 As Single
        Dim m2 As Single
        Dim mx1 As Single
        Dim mx2 As Single
        Dim my1 As Single
        Dim my2 As Single
        Dim dx As Single
        Dim dy As Single
        Dim rsqr As Single
        Dim drsqr As Single
        Dim xc As Single
        Dim yc As Single
        InCircle = False

        If y1 = y2 And y2 = y3 Then
            'MsgBox("INCIRCUM - F - Points are coincident !!")
            Exit Function
        ElseIf y2 = y1 Then
            m2 = -(x3 - x2) / (y3 - y2)
            mx2 = (x2 + x3) / 2
            my2 = (y2 + y3) / 2
            xc = (x2 + x1) / 2
            yc = m2 * (xc - mx2) + my2
        ElseIf y3 = y2 Then
            m1 = -(x2 - x1) / (y2 - y1)
            mx1 = (x1 + x2) / 2
            my1 = (y1 + y2) / 2
            xc = (x3 + x2) / 2
            yc = m1 * (xc - mx1) + my1
        Else
            m1 = -(x2 - x1) / (y2 - y1)
            m2 = -(x3 - x2) / (y3 - y2)
            mx1 = (x1 + x2) / 2
            mx2 = (x2 + x3) / 2
            my1 = (y1 + y2) / 2
            my2 = (y2 + y3) / 2
            xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2)
            yc = m1 * (xc - mx1) + my1
        End If

        dx = x2 - xc
        dy = y2 - yc
        rsqr = dx * dx + dy * dy
        dx = xp - xc
        dy = yp - yc
        drsqr = dx * dx + dy * dy

        If drsqr <= rsqr Then InCircle = True
    End Function
    Private Shared Function WhichSide(ByRef xp As Integer, ByRef yp As Integer, ByRef x1 As Integer, ByRef y1 As Integer, ByRef x2 As Integer, ByRef y2 As Integer) As Short
        'Determines which side of a line the point (xp,yp) lies.
        'The line goes from (x1,y1) to (x2,y2)
        'Returns -1 for a point to the left
        '         0 for a point on the line
        '        +1 for a point to the right

        Dim equation As Double = ((yp - y1) * (x2 - x1)) - ((y2 - y1) * (xp - x1))

        If equation > 0 Then
            WhichSide = -1
        ElseIf equation = 0 Then
            WhichSide = 0
        Else
            WhichSide = 1
        End If

    End Function


    Public Shared Function FindZValue(ByRef Vertex() As Vector3, ByRef Triangles() As Triangle_Calc, ByRef TriangleCount As Integer, ByVal x As Integer, ByVal y As Integer) As Single
        FindZValue = 0
        For i = 0 To TriangleCount
            If InTriangle(Vertex, x, y, Triangles(i).A, Triangles(i).B, Triangles(i).C) = True Then
                FindZValue = PlanePoint(x, y, Vertex(Triangles(i).A), Vertex(Triangles(i).B), Vertex(Triangles(i).C))
                If FindZValue > 0 Then
                    Exit Function
                End If
            End If
        Next
    End Function
    Private Shared Function InTriangle(ByRef Vertex() As Vector3, ByVal x As Integer, ByVal y As Integer, ByVal v0 As Integer, ByVal v1 As Integer, ByVal v2 As Integer) As Boolean
        InTriangle = False
        Dim v0x As Single = Vertex(v0).X
        Dim v0y As Single = Vertex(v0).Y
        Dim v1x As Single = Vertex(v1).X
        Dim v1y As Single = Vertex(v1).Y
        Dim v2x As Single = Vertex(v2).X
        Dim v2y As Single = Vertex(v2).Y
        Dim side1 As Single = WhichSide(x, y, v0x, v0y, v1x, v1y)
        Dim side2 As Single = WhichSide(x, y, v1x, v1y, v2x, v2y)
        Dim side3 As Single = WhichSide(x, y, v2x, v2y, v0x, v0y)

        If (side1 = 0) And (side2 = 0) Then InTriangle = True
        If (side1 = 0) And (side3 = 0) Then InTriangle = True
        If (side2 = 0) And (side3 = 0) Then InTriangle = True
        If (side1 = 0) And (side2 = side3) Then InTriangle = True
        If (side2 = 0) And (side1 = side3) Then InTriangle = True
        If (side3 = 0) And (side1 = side2) Then InTriangle = True
        If (side1 = side2) And (side2 = side3) Then InTriangle = True
    End Function
    Private Shared Function PlanePoint(ByVal x As Double, ByVal y As Double, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3) As Double
        Dim a As Double = p1.Y * (p2.Z - p3.Z) + p2.Y * (p3.Z - p1.Z) + p3.Y * (p1.Z - p2.Z)
        Dim b As Double = p1.Z * (p2.X - p3.X) + p2.Z * (p3.X - p1.X) + p3.Z * (p1.X - p2.X)
        Dim c As Double = p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)
        Dim d As Double = -p1.X * (p2.Y * p3.Z - p3.Y * p2.Z) - p2.X * (p3.Y * p1.Z - p1.Y * p3.Z) - p3.X * (p1.Y * p2.Z - p2.Y * p1.Z)

        If (Math.Abs(c) > 0.01) Then
            PlanePoint = (-(a * x + b * y + d) / c)
        Else
            PlanePoint = 0
        End If
    End Function

End Class

