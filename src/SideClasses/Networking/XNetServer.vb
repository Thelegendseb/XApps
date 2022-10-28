Imports System.Net.Sockets
Namespace Networking
    Public Class XNetServer
        Inherits XNetNode
        Public Event ClientReceived(AcceptedSocket As Socket)
        Sub New()
            MyBase.New()
        End Sub
        Sub New(SocketIn As Socket)
            MyBase.New(SocketIn)
        End Sub
        Protected Overrides Sub OnListen()
            Me.Socket_.Listen(0)
            Dim tempSocket As Socket = Me.Socket_.Accept()
            RaiseEvent ClientReceived(tempSocket)
        End Sub
    End Class

End Namespace