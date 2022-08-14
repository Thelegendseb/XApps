Imports System.Net
Imports System.Net.Sockets
Namespace Networking
    Public Class XServerLinker
        Private master As Socket
        Private endpoint As IPEndPoint
        Private Connected As Boolean
        Sub New()
            Me.master = GetMasterSocket()
        End Sub
        Public Sub InjectEndpointAddress(serverip As String, Optional port As Integer = 8888)
            Me.endpoint = New IPEndPoint(IPAddress.Parse(serverip), port)
        End Sub
        Public Sub InitiateConnection()
            If IsNothing(Me.endpoint) Then Throw New Exception("Endpoint Address must be injected before connection is made.")
            If Me.master.Connected Then
                Me.master.Close()
            End If
            Me.master.Connect(Me.endpoint)
            Me.Connected = True
        End Sub
        Public Shared Function GetMasterSocket() As Socket
            Return New Socket(AddressFamily.InterNetwork,
                                             SocketType.Stream,
                                             ProtocolType.Tcp)
        End Function
        Public Function GetSocket() As Socket
            Return Me.master
        End Function
        Public Function GetEndpoint() As IPEndPoint
            Return Me.endpoint
        End Function
        Public Function IsConnected() As Boolean
            Return Me.Connected
        End Function
        Public Sub KillConnection()
            Me.master.Close()
            Me.Connected = False
        End Sub
    End Class
End Namespace
