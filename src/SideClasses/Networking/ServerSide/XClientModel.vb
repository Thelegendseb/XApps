Imports System.Net
Imports System.Net.Sockets
Imports XApps.Networking.Server
Namespace Networking
    Namespace Server
        Public Class XClientModel
            Protected ModelSocket As Socket
            Protected Server As XServer
            Protected ListenerAsync As Task
            Sub New(AssignedSocket As Socket, ServerIn As XServer)
                Me.ModelSocket = AssignedSocket
                Me.Server = ServerIn
                Me.ListenerAsync = New Task(AddressOf Me.Inbound)
                Me.ListenerAsync.Start()
            End Sub
            Public Sub Send(data() As Byte)
                Me.ModelSocket.Send(data)
            End Sub
            Private Sub Inbound()
                While Me.ModelSocket.Connected
                    Dim readByte As Integer
                    Try
                        Dim pData(Me.ModelSocket.SendBufferSize) As Byte
                        readByte = Me.ModelSocket.Receive(pData)
                        Dim rData(readByte) As Byte
                        Array.Copy(pData, rData, readByte)
                        Me.Server.TriggerSentMessage(rData, Me)
                    Catch Ex As Exception
                        Exit Sub
                    End Try
                End While
            End Sub
        End Class
    End Namespace
End Namespace

