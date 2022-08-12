Imports System.Numerics
Public Class Transform

    Private Position As Vector3
    ' // A 3D point representing the centre of a Shape

    Private Rotation As RotationComponent
    ' // An object representing the rotation of a Shape

    Private Scale As ScaleComponent
    ' // An object representing the scale of a Shape
    Sub New()
        ' // Initialize Attributes
        Me.Position = Vector3.Zero
        Me.Rotation = New RotationComponent
        Me.Scale = New ScaleComponent
    End Sub
    Public Sub SetPosition(val As Vector3)
        Me.Position = val
    End Sub
    Public Function GetPosition() As Vector3
        Return Me.Position
    End Function
    Public Function GetRotation() As RotationComponent
        Return Me.Rotation
    End Function
    Public Function GetScale() As ScaleComponent
        Return Me.Scale
    End Function

End Class
