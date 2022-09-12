Public Class XComponent
    Inherits XBase
    Sub New()
        Me.SetUpdateStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        Throw New NotImplementedException()
    End Sub
End Class
