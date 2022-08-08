Public Class AnimationCollection
    Public CurrentAnimation As Animation
    Private Animations As List(Of Animation)
    Sub New()
        Me.Animations = New List(Of Animation)
    End Sub
    Sub New(L As List(Of Animation))
        Me.Animations = L
    End Sub
    Public Sub Update()
        Me.CurrentAnimation.UpdateOnTick()
    End Sub
End Class
