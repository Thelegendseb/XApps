Public Class XApp
    Public Session As XSession
    Sub New(FormIn As Form)
        Session = New XSession(FormIn)
    End Sub
    Public Sub Run()
        Session.Begin()
    End Sub
End Class
