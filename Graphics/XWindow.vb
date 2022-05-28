Public Class XWindow
    Inherits Panel

    '==================================

    'This class provides the services of:

    'A moveable window that can contain graphical images.

    'When Declared with events, you can easily handle to the events of the window.

    '==================================
    Private MouseBox As Rectangle
    Private MouseBoxDimension As Byte
    Private g As BufferedGraphics
    Private b As BufferedGraphicsContext
    Sub New(ByRef Container As Control) '{Panel And/Or Form}
        MyBase.New()
        Me.Location = New Point(0, 0)
        Me.Size = New Size(Container.ClientSize.Width, Container.ClientSize.Height)
        Init()
        Container.Controls.Add(Me)
        Me.Select()
    End Sub
    Private Sub Init()
        Me.BorderStyle = BorderStyle.None
        Me.b = BufferedGraphicsManager.Current
        Me.g = Me.b.Allocate(Me.CreateGraphics, Me.DisplayRectangle)
        Me.MouseBoxDimension = 4
        Me.MouseBox = New Rectangle(0, 0, Me.MouseBoxDimension, Me.MouseBoxDimension)
    End Sub
    Private Sub UpdateMouseBox(e As MouseEventArgs)
        Me.MouseBox = New Rectangle(e.X - MouseBoxDimension, e.Y - MouseBoxDimension, MouseBoxDimension * 2, MouseBoxDimension * 2)
    End Sub
    '==================================
    ' Events
    '==================================
    Private Sub Window_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        UpdateMouseBox(e)
    End Sub

    '=======================================
    '   Public Procedures/Functions
    '   {All of these are optional to the running of the session}
    '=======================================
    Public Sub SetMouseBoxDimension(val As Byte)
        Me.MouseBoxDimension = val
    End Sub
    Public Function GetGraphics() As Graphics
        Return Me.g.Graphics
    End Function
    Public Sub EndDrawing()
        Me.g.Render()
    End Sub
End Class
