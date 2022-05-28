Public Class XApp
    Public WithEvents Session As XSession
    Sub New(FormIn As Form)
        Session = New XSession(FormIn)
        Init(FormIn)
    End Sub
    Private Sub Init(FormIn As Form)
        AddHandlers(FormIn)
    End Sub
    Private Sub AddHandlers(FormIn As Form)
        AddHandler Me.Session.Window.MouseDown, AddressOf Me.MouseDown
        AddHandler Me.Session.Window.MouseUp, AddressOf Me.MouseUp
        AddHandler FormIn.KeyDown, AddressOf Me.KeyDown
        AddHandler FormIn.KeyUp, AddressOf Me.KeyUp
        AddHandler FormIn.ResizeEnd, AddressOf FormResize
    End Sub
    Overridable Sub MouseDown(sender As Object, e As MouseEventArgs)
    End Sub
    Overridable Sub MouseUp(sender As Object, e As MouseEventArgs)
    End Sub
    Overridable Sub KeyDown(sender As Object, e As KeyEventArgs)
    End Sub
    Overridable Sub KeyUp(sender As Object, e As KeyEventArgs)
    End Sub
    '============================================================
    Public Sub FormResize(sender As Object, e As EventArgs)

    End Sub
End Class
