Public Class XObjHolder

    Public MainList As List(Of XBase)
    Public WhiteList As List(Of XBase)
    Public QueueList As List(Of XBase)
    Public SubLists As Dictionary(Of Type, List(Of XBase))

    Public Sub New()
        Me.MainList = New List(Of XBase)
        Me.WhiteList = New List(Of XBase)
        Me.QueueList = New List(Of XBase)
    End Sub

End Class
