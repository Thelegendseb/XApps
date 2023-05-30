Imports System.IO
Imports System.Net.Sockets
Imports XApps.Networking
Namespace Networking
    Public Class XNetTransmitter
        Inherits XNetNode
        Protected Buffer As MemoryStream
        Private Receiving As Boolean
        Private Expected, Current As Integer
        Public Event DataSent(data() As Byte)
        Public Event DataReceived(data() As Byte)
        Public Event DataReceived_Stream(data As MemoryStream)
        Sub New()
            MyBase.New()
        End Sub
        Sub New(SocketIn As Socket)
            MyBase.New(SocketIn)
        End Sub
        Protected Overrides Sub OnListen()
            Dim Packet() As Byte = GetAwaitedNextPacket()
            If Not Me.Receiving Then
                ' // Packet represents inspector
                Me.Expected = BitConverter.ToInt32(Packet, 0)
                Me.Receiving = True
                Me.Current = 0
            Else
                Me.Buffer.Write(Packet)
                Me.Current += Packet.Length
                If Me.Current >= Me.Expected Then
                    Me.Receiving = False
                    RaiseEvent DataReceived(Me.Buffer.ToArray)
                    RaiseEvent DataReceived_Stream(Me.Buffer)
                    Me.Buffer.SetLength(0)
                End If
            End If
        End Sub
        Public Sub Send(data() As Byte)
            If Me.Running Then
                Dim size As Int32 = data.Length
                Me.Socket_.Send(BitConverter.GetBytes(size))
                Me.Socket_.Send(data)
                RaiseEvent DataSent(data)
            Else
                Throw New Exception("Must start the Transmitter to send messages")
            End If
        End Sub
        Private Function GetAwaitedNextPacket() As Byte()
            Dim readByte As Integer = 0
            Dim Pdata() As Byte
            ReDim Pdata(Me.Socket_.SendBufferSize)
            readByte = Me.Socket_.Receive(Pdata)
            Dim rData(readByte) As Byte
            Array.Copy(Pdata, rData, readByte)
            Return rData
        End Function
        Protected Overrides Sub Initialize()
            MyBase.Initialize()
            Me.Buffer = New MemoryStream
        End Sub
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            Me.Buffer.Dispose()
        End Sub
    End Class
End Namespace