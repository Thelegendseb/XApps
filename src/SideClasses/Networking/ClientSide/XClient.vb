﻿Imports System.Threading
Namespace Networking
    Namespace Client
        Public Class XClient

            ' // XClient is a multithreaded class

            ' // Inbound Data will be running Asynchronously

            ' // Main thread can listen to the events and parse when needed

            Public Event MessageSent(data() As Byte)
            Public Event MessageReceived(data() As Byte)
            Protected ServerLinker As XServerLinker
            Protected Running As Boolean
            Protected InboundAsync As Task
            Sub New()
                Me.ServerLinker = New XServerLinker
                Me.InboundAsync = New Task(AddressOf Me.Inbound)
            End Sub
            Public Sub Connect(IPEndPoint As String, port As Integer)
                Me.ServerLinker.InjectEndpointAddress(IPEndPoint, port)
                Me.ServerLinker.InitiateConnection()
            End Sub
            Public Sub Start()
                If Me.ServerLinker.IsConnected Then
                    Me.Running = True
                    Me.InboundAsync.Start()
                End If
            End Sub
            Public Sub [Stop]()
                Me.Running = False
            End Sub
            Public Sub Send(data() As Byte)
                If Me.Running Then
                    Me.ServerLinker.GetSocket.Send(data)
                    RaiseEvent MessageSent(data)
                Else
                    Throw New Exception("A connection must be existent to send data to a server.")
                End If
            End Sub
            ' // ==================================
            Private Sub Inbound()
                While Me.Running
                    Dim readByte As Integer
                    Try
                        Dim pData(Me.ServerLinker.GetSocket.SendBufferSize) As Byte
                        readByte = Me.ServerLinker.GetSocket.Receive(pData)
                        Dim rData(readByte) As Byte
                        Array.Copy(pData, rData, readByte)
                        RaiseEvent MessageReceived(rData)
                    Catch Ex As Exception
                        Me.Running = False
                        Exit Sub
                    End Try
                End While
            End Sub
        End Class
    End Namespace
End Namespace
