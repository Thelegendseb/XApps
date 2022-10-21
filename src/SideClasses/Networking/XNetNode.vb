Imports System.Net
Imports System.Net.Sockets
Public MustInherit Class XNetNode
    Protected Running As Boolean
    Protected Socket_ As Socket
    Protected ListenerTask As Task
    Sub New()
        Me.Socket_ = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Initialize()
    End Sub
    Sub New(SocketIn As Socket)
        If IsNothing(SocketIn) Then
            Throw New NullReferenceException
        End If
        Me.Socket_ = SocketIn
        Initialize()
    End Sub
    Public Sub Start()
        If Not Me.Running Then
            Me.ListenerTask.Start()
            Me.Running = True
        End If
    End Sub
    Public Sub [Stop]()
        If Me.Running Then
            Me.Running = False
        End If
    End Sub
    Private Sub Listen()
        While Me.Running
            OnListen()
        End While
    End Sub
    Protected MustOverride Sub OnListen()
    Protected Overridable Sub Initialize()
        Me.ListenerTask = New Task(AddressOf Me.Listen)
    End Sub
    Public Sub BindSocket(ipv4 As String, port As Integer)
        Me.Socket_.Bind(New IPEndPoint(IPAddress.Parse(ipv4), port))
    End Sub
    Public Sub ConnectSocket(ipv4 As String, port As Integer)
        Me.Socket_.Connect(New IPEndPoint(IPAddress.Parse(ipv4), port))
    End Sub
    Public Sub DisconnectSocket()
        Me.Socket_.Close()
        Me.Socket_.Disconnect(True)
    End Sub
    Public Overridable Sub Dispose()
        If Me.Running Then
            Me.Stop()
        End If
        Me.Socket_.Dispose()
        Me.ListenerTask.Dispose()
    End Sub
    Public Function GetSocket() As Socket
        Return Me.Socket_
    End Function
End Class
