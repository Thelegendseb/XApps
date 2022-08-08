Imports System.Numerics
Public Class Math3D
    Public Shared Function DegreesToRadians(val As Double) As Double
        Return val * (Math.PI / 180)
    End Function
    Public Shared Function Midpoint3D(L As List(Of Vector3)) As Vector3
        Dim R As New Vector3
        For Each Vertex As Vector3 In L
            R.X += Vertex.X
            R.Y += Vertex.Y
            R.Z += Vertex.Z
        Next
        R.X /= L.Count
        R.Y /= L.Count
        R.Z /= L.Count
        Return R
    End Function
    Public Shared Function RemoveZComponent(L As List(Of Vector3)) As List(Of Point)
        Dim CState2D As New List(Of Point)
        For Each Point3D In L
            CState2D.Add(New Point(Point3D.X, Point3D.Y))
        Next
        Return CState2D
    End Function
    Public Shared Function VectorToPoint(Vin As Vector3) As Point
        Return New Point(Vin.X, Vin.Y)
    End Function

    Public Class Matrix

        'FIX THIS
        Public Shared Function Multiply(matrix(,) As Single, V As Vector3) As Vector3

            If matrix.GetLength(0) = 2 Then


                Return New Vector3(matrix(0, 0) * V.X +
                                     matrix(0, 1) * V.Y +
                                     matrix(0, 2) * V.Z,
                                     matrix(1, 0) * V.X +
                                     matrix(1, 1) * V.Y +
                                     matrix(1, 2) * V.Z,
                                     V.Z)

            ElseIf matrix.GetLength(0) = 3 Then

                Return New Vector3(matrix(0, 0) * V.X +
                                     matrix(0, 1) * V.Y +
                                     matrix(0, 2) * V.Z,
                                     matrix(1, 0) * V.X +
                                     matrix(1, 1) * V.Y +
                                     matrix(1, 2) * V.Z,
                                     matrix(2, 0) * V.X +
                                     matrix(2, 1) * V.Y +
                                     matrix(2, 2) * V.Z)
            End If

            Return V
        End Function

        Public Shared Function Type(typein As Char, angle As Double) As Single(,)
            typein = UCase(typein)
            If typein = "Z" Then
                Return {
            {CSng(Math.Cos(angle)), CSng(-Math.Sin(angle)), 0},
            {CSng(Math.Sin(angle)), CSng(Math.Cos(angle)), 0},
            {0, 0, 1}
            }
            ElseIf typein = "X" Then
                Return {
                    {1, 0, 0},
            {0, CSng(Math.Cos(angle)), CSng(-Math.Sin(angle))},
            {0, CSng(Math.Sin(angle)), CSng(Math.Cos(angle))}
            }
            ElseIf typein = "Y" Then
                Return {
            {CSng(Math.Cos(angle)), 0, CSng(-Math.Sin(angle))},
            {0, 1, 0},
            {CSng(Math.Sin(angle)), 0, CSng(Math.Cos(angle))}
            }
            Else : Return {
                    {CSng(0), 0, 0},
                    {0, 0, 0},
                    {0, 0, 0}
                    }
            End If
        End Function

    End Class
End Class
