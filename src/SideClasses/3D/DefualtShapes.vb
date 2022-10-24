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

        OctahedronOut.GetFaces.Add(New Face({0, 2, 3}))
        OctahedronOut.GetFaces.Add(New Face({0, 4, 5}))
        OctahedronOut.GetFaces.Add(New Face({0, 2, 4}))
        OctahedronOut.GetFaces.Add(New Face({0, 3, 5}))

        OctahedronOut.GetFaces.Add(New Face({1, 2, 3}))
        OctahedronOut.GetFaces.Add(New Face({1, 4, 5}))
        OctahedronOut.GetFaces.Add(New Face({1, 2, 4}))
        OctahedronOut.GetFaces.Add(New Face({1, 3, 5}))

        Return OctahedronOut

    End Function

    Public Shared Function Pyramid() As Shape

        Dim PyramidOut As New Shape

        PyramidOut.GetVertices.Add(New Vector3(0, -1, 0))
        PyramidOut.GetVertices.Add(New Vector3(-0.5, 0.5, -0.5))
        PyramidOut.GetVertices.Add(New Vector3(-0.5, 0.5, 0.5))
        PyramidOut.GetVertices.Add(New Vector3(0.5, 0.5, -0.5))
        PyramidOut.GetVertices.Add(New Vector3(0.5, 0.5, 0.5))

        PyramidOut.GetFaces.Add(New Face({0, 1, 2}))
        PyramidOut.GetFaces.Add(New Face({0, 3, 4}))
        PyramidOut.GetFaces.Add(New Face({0, 1, 3}))
        PyramidOut.GetFaces.Add(New Face({0, 2, 4}))

        PyramidOut.GetFaces.Add(New Face({1, 2, 4, 3}))

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


        Return HexagonalPrismOut

    End Function
    Public Shared Function Cylinder() As Shape
        Dim CylinderOut As Shape = N_SidedRegularPrism(20)
        Return CylinderOut
    End Function
    Public Shared Function Icosahedron() As Shape

        Dim IcosahedronOut As New Shape

        IcosahedronOut.GetVertices.Add(New Vector3(0, -1, 0))

        IcosahedronOut.GetVertices.Add(New Vector3(0, -1 + (2 / 3), 0.9))
        IcosahedronOut.GetVertices.Add(New Vector3(-0.75, -1 + (2 / 3), 0.2))
        IcosahedronOut.GetVertices.Add(New Vector3(0.75, -1 + (2 / 3), 0.2))
        IcosahedronOut.GetVertices.Add(New Vector3(0.4, -1 + (2 / 3), -0.75))
        IcosahedronOut.GetVertices.Add(New Vector3(-0.4, -1 + (2 / 3), -0.75))

        IcosahedronOut.GetVertices.Add(New Vector3(0, 1, 0))

        IcosahedronOut.GetVertices.Add(New Vector3(0, 1 - (2 / 3), -0.9))
        IcosahedronOut.GetVertices.Add(New Vector3(-0.75, 1 - (2 / 3), -0.2))
        IcosahedronOut.GetVertices.Add(New Vector3(0.75, 1 - (2 / 3), -0.2))
        IcosahedronOut.GetVertices.Add(New Vector3(0.4, 1 - (2 / 3), 0.75))
        IcosahedronOut.GetVertices.Add(New Vector3(-0.4, 1 - (2 / 3), 0.75))


        Return IcosahedronOut

    End Function
    Public Shared Function N_SidedRegularPrism(SideCount As Integer)
        Dim ShapeOut As New Shape
        Dim mystep As Decimal = (2 * Math.PI) / SideCount
        For Y = 1 To -1 Step -2
            For i = 0 To 2 * Math.PI Step mystep
                Dim X As Decimal = Math.Cos(i)
                Dim Z As Decimal = Math.Sin(i)
                ShapeOut.GetVertices.Add(New Vector3(X, Y, Z))
            Next
        Next

        ' top face
        Dim sides() As Integer
        For i = 0 To SideCount - 1
            ReDim Preserve sides(i)
            sides(i) = i
        Next
        ShapeOut.GetFaces.Add(New Face(sides))

        ' bottom face 
        ReDim sides(0)
        For i = 0 To SideCount - 1
            ReDim Preserve sides(i)
            sides(i) = i + (SideCount)
        Next
        ShapeOut.GetFaces.Add(New Face(sides))

        ' side faces
        'ReDim sides(0)
        'For i = 0 To SideCount - 2
        '    ReDim sides(3)
        '    sides(0) = i + 1
        '    sides(1) = i + (SideCount)
        '    sides(2) = i
        '    sides(3) = i + (SideCount) + 1
        '    ShapeOut.GetFaces.Add(New Face(sides))
        'Next
        'ReDim sides(3)
        'sides(0) = 0
        'sides(1) = 0 + (SideCount)
        'sides(2) = (SideCount - 2) + 1
        'sides(3) = (SideCount - 2) + 1
        'ShapeOut.GetFaces.Add(New Face(sides))

        Return ShapeOut
    End Function
End Class

