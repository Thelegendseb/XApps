Imports System.Numerics
Public Class Transform

    Public Position As Vector3
    ' // A 3D point representing the centre of a Shape

    Public Rotation As RotationComponent
    ' // An object representing the rotation of a Shape

    Public Scale As ScaleComponent
    ' // An object representing the scale of a Shape
    Sub New()
        ' // Initialize Attributes
        Me.Position = Vector3.Zero
        Me.Rotation = New RotationComponent
        Me.Scale = New ScaleComponent
    End Sub
End Class
