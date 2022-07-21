Public Class Animation
    Private CurrentFrame As Bitmap
    Private Frames As List(Of Bitmap)
    Private CurrentFrameIndex As Integer
    Private FrameDelayInTicks As Integer
    Private CurrentTick As Integer
    Sub New(FrameList As List(Of Bitmap))
        If FrameList.Count = 0 Then Throw New Exception("List must contain 1 frame or more")
        Me.Frames = FrameList
    End Sub
    Public Sub UpdateOnTick()
        ' // Method must be called on the tick
        Me.CurrentTick += 1
        If Me.CurrentTick >= Me.FrameDelayInTicks Then
            ' // Switch to next frame
            Me.CurrentTick = 0
            Me.CurrentFrameIndex += 1
            If Me.CurrentFrameIndex >= Me.Frames.Count Then
                Me.CurrentFrameIndex = 0
            End If
        End If
        Me.CurrentFrame = Me.Frames(Me.CurrentFrameIndex)
    End Sub
    Public Sub SetFrameDelayInTicks(val As Integer)
        Me.FrameDelayInTicks = val
    End Sub
    Public Function GetFrameDelayInTicks() As Integer
        Return Me.FrameDelayInTicks
    End Function
    Public Function GetCurrentFrame() As Bitmap
        Return Me.CurrentFrame
    End Function
    Public Function GetFrames() As List(Of Bitmap)
        Return Me.Frames
    End Function
    Public Sub AddFrame(FrameIn As Bitmap)
        Me.Frames.Add(FrameIn)
    End Sub
    Public Sub RemoveFrame(FrameIn As Bitmap)
        Me.Frames.Remove(FrameIn)
    End Sub
End Class