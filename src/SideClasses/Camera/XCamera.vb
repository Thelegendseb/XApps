Imports AForge.Video
Imports AForge.Video.DirectShow
Public Class XCamera
    Public Running As Boolean = False
    Public FrameCapture As Bitmap
    Private Component As VideoCaptureDevice
    Public Event OnFrameEnd(ByRef BitmapRef As Bitmap)
    Sub New()
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog = DialogResult.OK Then
            Me.Component = cameras.VideoDevice
            AddHandler Me.Component.NewFrame, New NewFrameEventHandler(AddressOf Me.OnNewFrame)
        Else
            Application.Exit()
        End If
    End Sub
    Private Sub OnNewFrame(sender As Object, e As NewFrameEventArgs)
        If Me.Running = True Then
            Dim Old As Image = Me.FrameCapture
            Me.FrameCapture = DirectCast(e.Frame.Clone, Bitmap)
            If Old IsNot Nothing Then
                Old.Dispose()
            End If
            RaiseEvent OnFrameEnd(Me.FrameCapture)
        End If
    End Sub
    '=============================================================
    Public Sub StartFeed()
        Me.Component.Start()
        Me.Running = True
    End Sub
    Public Sub EndFeed()
        Me.Component.SignalToStop()
        Me.Running = False
    End Sub
    Public Function GetCurrentFrame() As Bitmap
        Return Me.FrameCapture
    End Function
End Class
