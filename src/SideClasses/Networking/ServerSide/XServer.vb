﻿Imports System.Net
Imports System.Net.Sockets
Namespace Networking

    Namespace Server
        Public Class XServer

            ' // Class will be running Asynchronously (listening to new connections)

            Protected Running As Boolean
            Protected MasterSocket As Socket
            Protected Clients As List(Of XClientModel)
            Protected ListenerAsync As Task

            Sub New(HostIP As String, Port As Integer)
                Me.Clients = New List(Of XClientModel)
                Me.InitializeSocket(HostIP, Port)
                Me.InitializeListenerAsync()
            End Sub
            Public Sub Start()
                Me.Running = True
                Me.ListenerAsync.Start()
            End Sub
            Public Sub [Stop]()
                Me.Running = False
            End Sub
            Public Function GetClients() As List(Of XClientModel)
                Return Me.Clients
            End Function
            Private Sub InitializeSocket(HostIP As String, Port As Integer)
                Me.MasterSocket = XServerLinker.GetMasterSocket
                Me.MasterSocket.Bind(New IPEndPoint(IPAddress.Parse(HostIP), Port))
            End Sub
            Private Sub InitializeListenerAsync()
                Me.ListenerAsync = New Task(AddressOf Me.Listen)
            End Sub
            Private Sub Listen()
                While Me.Running
                    Try

                        Me.MasterSocket.Listen()
                        ' // Accept any inbound client
                        Dim S As Socket = Me.MasterSocket.Accept()
                        Dim Client As New XClientModel(S)
                        Me.Clients.Add(Client)

                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try
                End While
            End Sub
        End Class

    End Namespace

End Namespace

