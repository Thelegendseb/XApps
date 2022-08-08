Public Class RotationComponent
    ' // All Rotation values mesured in radians

    Public Yaw As Double
    ' // Angle of rotation along the Vertical Axis - Around Y Axis

    Public Roll As Double
    ' // Angle of rotation along the Longitudinal Axis - Around Z Axis

    Public Pitch As Double
    ' // Angle of rotation along the Lateral Axis - Around X Axis

    ' ================================
    ' // Convertor for each attribute into degrees
    Public Function YawToDegrees() As Double
        Return Me.Yaw * (180 / Math.PI)
    End Function
    Public Function RollToDegrees() As Double
        Return Me.Roll * (180 / Math.PI)
    End Function
    Public Function PitchToDegrees() As Double
        Return Me.Pitch * (180 / Math.PI)
    End Function
    ' ================================

    ' // Clamp Methods allow values to not be above 2PI or below 0.


    ' // ForceClamp methods manage all extensions to the nearest bound:

    '   x < 0 => 0 | x > 2PI => 2PI

    ' // LetClamp methods manage all extensions as a continuation of theta:

    '   x < 0 => 2PI + x | x > 2PI => x = x - 2PI
    Public Sub ForceClampAll()
        Me.ForceClampYaw()
        Me.ForceClampRoll()
        Me.ForceClampPitch()
    End Sub
    Public Sub ForceClampYaw()
        If Me.Yaw < 0 Then Me.Yaw = 0
        If Me.Yaw > 2 * Math.PI Then Me.Yaw = 2 * Math.PI
    End Sub
    Public Sub ForceClampRoll()
        If Me.Roll < 0 Then Me.Roll = 0
        If Me.Roll > 2 * Math.PI Then Me.Roll = 2 * Math.PI
    End Sub
    Public Sub ForceClampPitch()
        If Me.Pitch < 0 Then Me.Pitch = 0
        If Me.Pitch > 2 * Math.PI Then Me.Pitch = 2 * Math.PI
    End Sub
    ' - - - - - - -
    Public Sub LetClampAll()
        Me.LetClampYaw()
        Me.LetClampRoll()
        Me.LetClampPitch()
    End Sub
    Public Sub LetClampYaw()
        If Me.Yaw < 0 Then Me.Yaw = 2 * Math.PI + Me.Yaw
        If Me.Yaw > 2 * Math.PI Then Me.Yaw -= 2 * Math.PI
    End Sub
    Public Sub LetClampRoll()
        If Me.Roll < 0 Then Me.Roll = 2 * Math.PI + Me.Roll
        If Me.Roll > 2 * Math.PI Then Me.Roll -= 2 * Math.PI
    End Sub
    Public Sub LetClampPitch()
        If Me.Pitch < 0 Then Me.Pitch = 2 * Math.PI + Me.Pitch
        If Me.Pitch > 2 * Math.PI Then Me.Pitch -= 2 * Math.PI
    End Sub
End Class
