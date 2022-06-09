Public Class Renderer2D

    '==============================
    '   Renderer

    '   Primary Usage is the rendering of Shapes.TwoD objects to account for rotation

    '   This class is responsible for rendering the objects contained in its list pointer.
    '   Regardless of an objects Draw Status, it will be rendered.
    '   {To be changed at a later date}
    '==============================
    Inherits XBase
    Private ObjectListPointer As List(Of Shapes.TwoD.TwoDBase)
    Sub New(Session As XSession)
        Session.QueueRelease()
        ResetPointer(Session)
        Me.SetDrawStatus(True)
    End Sub
    Public Sub ResetPointer(Session As XSession)
        Me.ObjectListPointer = Nothing
        Me.ObjectListPointer = Session.GetMatches(Of Shapes.TwoD.TwoDBase)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        ResetPointer(Session)
    End Sub
    Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
        Using FrameMatrix As New System.Drawing.Drawing2D.Matrix
            For Each Shape As Shapes.TwoD.TwoDBase In Me.ObjectListPointer
                FrameMatrix.RotateAt(Shape.GetTheta, New PointF(Shape.GetX, Shape.GetY))
                g.Transform = FrameMatrix
                Shape.Draw(g)
                FrameMatrix.Reset()
            Next
        End Using
    End Sub
End Class
