Public MustInherit Class XBase
    Private SetToUpdate As Boolean
    Private SetToDispose As Boolean
    Private SetToDraw As Boolean
    Public MustOverride Sub Update(ByVal Session As XSession)
    Public MustOverride Sub Draw(ByRef g As Graphics)
    Public Sub SetDisposeStatus(ByVal WhiteList As Boolean)
        Me.SetToDispose = WhiteList
    End Sub
    Public Function IsSetToDispose() As Boolean
        Return Me.SetToDispose
    End Function
    Public Sub SetDrawStatus(ByVal WhiteList As Boolean)
        Me.SetToDraw = WhiteList
    End Sub
    Public Function IsSetToDraw() As Boolean
        Return Me.SetToDraw
    End Function
    Public Sub SetUpdateStatus(ByVal WhiteList As Boolean)
        Me.SetToUpdate = WhiteList
    End Sub
    Public Function IsSetToUpdate() As Boolean
        Return Me.SetToUpdate
    End Function
End Class
