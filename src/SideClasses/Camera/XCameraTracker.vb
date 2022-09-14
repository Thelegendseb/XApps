Public Class XCameraTracker
    Private LatestFrame As Bitmap
    Private CameraPtr As XCamera
    Sub New(ByRef CamPtr As XCamera)
        Me.CameraPtr = CamPtr
        AddHandler Me.CameraPtr.OnFrameEnd, AddressOf Me.OnCameraTrigger
    End Sub
    Private Sub OnCameraTrigger(ByRef Capture As Bitmap)
        Me.LatestFrame = Capture.Clone
        Capture.Dispose()
    End Sub
    Public Function GetLatestFrame() As Bitmap
        Return Me.LatestFrame
    End Function
End Class
