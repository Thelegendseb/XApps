Public Class XRenderer
    Inherits XBase
    Sub New()
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        Throw New NotImplementedException()
    End Sub
End Class
