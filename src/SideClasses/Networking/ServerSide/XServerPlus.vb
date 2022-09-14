Imports XApps.Networking.Server
Imports XApps.Networking
Public Class XServerPlus

    ' // Instead of just providing data per packet, XServerPlus
    ' // excepts a inspector before sending the data.

    ' // Data is recieved in packets if too large, and XServerPlus will
    ' // collect the packets and produce a single byte array 

    Inherits XServer
    Public Event ObjectReceived(data() As Byte, client As XClientModel)
    Public Event ObjectReceivedwLogger(data() As Byte, client As XClientModel, numOfPackets As Integer)
    Protected BufferStream As IO.MemoryStream
    Protected ReceivingObject As Boolean
    Protected CurrentByteCount As Integer
    Protected TotalByteCount As Integer
    Protected PacketCount As Integer
    Sub New(HostIP As String, Port As Integer)
        MyBase.New(HostIP, Port)
        Me.BufferStream = New IO.MemoryStream
        AddHandler Me.PacketReceived, AddressOf Me.OnPacketReceived
    End Sub
    Protected Sub OnPacketReceived(data() As Byte, client As XClientModel)
        If Not Me.ReceivingObject Then
            Dim Inspector As InboundNetworkInspector = Serializer.Deserialize(Of InboundNetworkInspector)(data)
            If IsNothing(Inspector) Then Throw New Exception("Data was unable to deserialize.")
            ResetTrackerAttributes()
            Me.ReceivingObject = True
            Me.TotalByteCount = Inspector.Length
        Else
            If Me.CurrentByteCount < Me.TotalByteCount Then
                Me.BufferStream.Write(data, 0, data.Length - 1)
                Me.CurrentByteCount += data.Length - 1
                Me.PacketCount += 1
                If Me.CurrentByteCount >= Me.TotalByteCount Then
                    Me.ReceivingObject = False
                    Dim allbytes() As Byte = Me.BufferStream.ToArray
                    RaiseEvent ObjectReceived(allbytes, client)
                    RaiseEvent ObjectReceivedwLogger(allbytes, client, Me.PacketCount)
                    ResetBufferStream()
                End If
            End If
        End If
    End Sub
    Protected Sub ResetTrackerAttributes()
        Me.PacketCount = 0
        Me.CurrentByteCount = 0
        Me.TotalByteCount = 0
    End Sub
    Protected Sub ResetBufferStream()
        Me.BufferStream.Flush()
        Me.BufferStream.Dispose()
        Me.BufferStream = New IO.MemoryStream
    End Sub

End Class
