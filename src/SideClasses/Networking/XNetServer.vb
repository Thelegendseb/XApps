Imports System.Net.Sockets
Namespace Networking
    Public Class XNetServer
        Inherits XNetNode
        Public Event ClientReceived(AcceptedSocket As Socket)
        Protected Overrides Sub Initialize()
            MyBase.Initialize()
            Me.BindSocket("127.0.0.1", 8888)
        End Sub
        Protected Overrides Sub OnListen()
            Me.Socket_.Listen(0)
            Dim tempSocket As Socket = Me.Socket_.Accept()
            RaiseEvent ClientReceived(tempSocket)
        End Sub
    End Class

End Namespace