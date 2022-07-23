Public Class XApp
    Private Parent As Form
    Public WithEvents Session As XSession
    Sub New(FormIn As Form)
        Me.Parent = FormIn
        Me.Session = New XSession(FormIn)
        Init(FormIn)
    End Sub
    Sub New()
        Dim FormIn As New Form
        Me.Parent = FormIn
        Me.Session = New XSession(FormIn)
        Init(FormIn)
    End Sub
    Public Sub Run()
        Me.Session.Begin()
    End Sub
    Public Sub Halt()
        Me.Session.Halt()
        GC.Collect()
        Application.Exit()
    End Sub
    Private Sub Init(FormIn As Form)
        AddHandlers(FormIn)
    End Sub
    Private Sub AddHandlers(FormIn As Form)
        AddHandler Me.Session.UpdateOccured, AddressOf Me.UpdateOccured
        '------------------------
        AddHandler Me.Session.Window.MouseDown, AddressOf Me.MouseDown
        AddHandler Me.Session.Window.MouseUp, AddressOf Me.MouseUp
        AddHandler Me.Session.Window.KeyDown, AddressOf Me.KeyDown
        AddHandler Me.Session.Window.KeyUp, AddressOf Me.KeyUp
        '------------------------
        AddHandler FormIn.SizeChanged, AddressOf Me.RegionChanged
    End Sub
    Overridable Sub UpdateOccured()
    End Sub
    Overridable Sub MouseDown(sender As Object, e As MouseEventArgs)
        Me.Session.MouseClicked(New Point(e.X, e.Y))
    End Sub
    Overridable Sub MouseUp(sender As Object, e As MouseEventArgs)
    End Sub
    Overridable Sub KeyDown(sender As Object, e As KeyEventArgs)
    End Sub
    Overridable Sub KeyUp(sender As Object, e As KeyEventArgs)
    End Sub
    '============================================================
    'MATCHING WINDOW TO FORM
    Private Sub RegionChanged(sender As Object, e As EventArgs)
        GC.Collect()
        Me.Session.Window.Size = Me.Parent.ClientSize
        Me.Session.SetBounds(Me.Parent.DisplayRectangle)
        Me.Session.Window.ResetBounds()
    End Sub
End Class
