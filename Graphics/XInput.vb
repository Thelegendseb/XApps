Public Class XInput

    '====================================
    ' XInput

    'This class is designed to be used with the XWindow class

    'The method of use is as follows:

    '1. Create an instance of the XInput class

    '2. Handle The KeyDown and KeyUp Events to a method containing the following code:

    'ManageUp(e)
    'ManageDown(e)

    '3. Any key checks can be refrenced by the IsDown and IsUp methods

    '====================================
    Private Parent As Control
    Private DownKeys As List(Of Keys)
    Private UpKeys As List(Of Keys)

    Public Sub New(Parent As Control)
        Me.Parent = Parent
        Me.DownKeys = New List(Of Keys)
        Me.UpKeys = New List(Of Keys)
        AddAllUpKeys()
        AddHandlers()
    End Sub
    Private Sub AddHandlers()
        AddHandler Me.Parent.KeyDown, AddressOf Me.ManageDown
        AddHandler Me.Parent.KeyUp, AddressOf Me.ManageUp
    End Sub
    Private Sub AddAllUpKeys()
        For Each key As Keys In [Enum].GetValues(GetType(Keys))
            Me.UpKeys.Add(key)
        Next
    End Sub
    Public Sub ManageUp(sender As Object, e As KeyEventArgs)
        If Me.DownKeys.Contains(e.KeyCode) Then
            Me.UpKeys.Add(e.KeyCode)
            Me.DownKeys.Remove(e.KeyCode)
        End If
    End Sub
    Public Sub ManageDown(sender As Object, e As KeyEventArgs)
        If Me.UpKeys.Contains(e.KeyCode) Then
            Me.UpKeys.Remove(e.KeyCode)
            Me.DownKeys.Add(e.KeyCode)
        End If
    End Sub
    Public Function IsDown(e As Keys) As Boolean
        Return Me.DownKeys.Contains(e)
    End Function
    Public Function IsUp(e As Keys) As Boolean
        Return Me.UpKeys.Contains(e)
    End Function
End Class
