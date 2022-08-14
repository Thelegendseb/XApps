Imports System.Net
Imports System.Net.Sockets
Public Class XClientModel
    Protected ModelSocket As Socket
    Sub New(AssignedSocket As Socket)
        Me.ModelSocket = AssignedSocket
    End Sub
    Public Sub Send(data() As Byte)
        Me.ModelSocket.Send(data)
    End Sub
End Class
