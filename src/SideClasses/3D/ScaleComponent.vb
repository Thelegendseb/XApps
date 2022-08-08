Public Class ScaleComponent
    ' // All Scaling values act as a multiplier 

    Public X, Y, Z As Double
    ' // Stretch of Shape in associative axis

    Public Sub SetAll(val As Double)
        Me.X = val
        Me.Y = val
        Me.Z = val
    End Sub
    Public Sub ForceClampAll()
        If Me.X < 0 Then
            Me.X = 0
        End If
        If Me.Y < 0 Then
            Me.Y = 0
        End If
        If Me.Z < 0 Then
            Me.Z = 0
        End If
    End Sub

End Class
