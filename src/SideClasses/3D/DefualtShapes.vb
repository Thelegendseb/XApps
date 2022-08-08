Imports System.Numerics
Public Class DefualtShapes
    Public Shared Function Cube() As Shape
        Dim CubeOut As New Shape

        CubeOut.GetVertices.Add(New Vector3(-1, -1, -1))
        CubeOut.GetVertices.Add(New Vector3(-1, -1, 1))
        CubeOut.GetVertices.Add(New Vector3(-1, 1, 1))
        CubeOut.GetVertices.Add(New Vector3(1, 1, 1))
        CubeOut.GetVertices.Add(New Vector3(1, -1, -1))
        CubeOut.GetVertices.Add(New Vector3(1, 1, -1))
        CubeOut.GetVertices.Add(New Vector3(1, -1, 1))
        CubeOut.GetVertices.Add(New Vector3(-1, 1, -1))

        CubeOut.GetFaces.Add(New Face({0, 1, 2, 7}))
        CubeOut.GetFaces.Add(New Face({3, 5, 4, 6}))
        CubeOut.GetFaces.Add(New Face({6, 4, 0, 1}))
        CubeOut.GetFaces.Add(New Face({2, 3, 5, 7}))
        CubeOut.GetFaces.Add(New Face({0, 4, 5, 7}))
        CubeOut.GetFaces.Add(New Face({1, 2, 3, 6}))

        CubeOut.GetTransform.Scale.SetAll(75)

        Return CubeOut

    End Function
    Public Shared Function Octahedron() As Shape

        Dim OctahedronOut As New Shape

        OctahedronOut.GetVertices.Add(New Vector3(0, 1, 0))
        OctahedronOut.GetVertices.Add(New Vector3(0, -1, 0))
        OctahedronOut.GetVertices.Add(New Vector3(-0.5, 0, -0.5))
        OctahedronOut.GetVertices.Add(New Vector3(0.5, 0, -0.5))
        OctahedronOut.GetVertices.Add(New Vector3(-0.5, 0, 0.5))
        OctahedronOut.GetVertices.Add(New Vector3(0.5, 0, 0.5))

        OctahedronOut.GetTransform.Scale.SetAll(100)

        Return OctahedronOut

    End Function

    Public Shared Function Pyramid() As Shape

        Dim PyramidOut As New Shape

        PyramidOut.GetVertices.Add(New Vector3(0, -1, 0))
        PyramidOut.GetVertices.Add(New Vector3(-0.5, 0.5, -0.5))
        PyramidOut.GetVertices.Add(New Vector3(-0.5, 0.5, 0.5))
        PyramidOut.GetVertices.Add(New Vector3(0.5, 0.5, -0.5))
        PyramidOut.GetVertices.Add(New Vector3(0.5, 0.5, 0.5))

        PyramidOut.GetTransform.Scale.SetAll(100)

        Return PyramidOut

    End Function
    Public Shared Function HexagonalPrism() As Shape

        Dim HexagonalPrismOut As New Shape

        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.25, -1, 0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.4, -1, 0))
        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.25, -1, -0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.25, -1, -0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.4, -1, 0))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.25, -1, 0.25))

        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.25, 1, 0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.4, 1, 0))
        HexagonalPrismOut.GetVertices.Add(New Vector3(-0.25, 1, -0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.25, 1, -0.25))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.4, 1, 0))
        HexagonalPrismOut.GetVertices.Add(New Vector3(0.25, 1, 0.25))

        HexagonalPrismOut.GetTransform.Scale.SetAll(120)

        Return HexagonalPrismOut

    End Function

    Public Shared Function Cylinder() As Shape

        Dim CylinderOut As New Shape

        For Y = 1 To -1 Step -2
            For i = 0 To 2 * Math.PI Step (2 * Math.PI) / 20
                Dim X As Double = Math.Cos(i)
                Dim Z As Double = Math.Sin(i)

                CylinderOut.GetVertices.Add(New Vector3(X, Y, Z))

            Next
        Next

        CylinderOut.GetTransform.Scale.SetAll(100)

        Return CylinderOut

    End Function
End Class
