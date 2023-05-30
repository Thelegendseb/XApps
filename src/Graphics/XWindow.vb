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
    Private ClearColor As Color
    Private MouseIsDown As Boolean

    Sub New(ByRef Container As Control) '{Panel And/Or Form}
        MyBase.New()
        Me.Location = New Point(0, 0)
        Me.ClearColor = Container.BackColor
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
    Public Sub ResetBounds()
        Me.g.Dispose()
        Me.g = Me.b.Allocate(Me.CreateGraphics, Me.DisplayRectangle)
    End Sub
    Private Sub UpdateMouseBox(e As MouseEventArgs)
        Me.MouseBox = New Rectangle(e.X - Me.MouseBoxDimension, e.Y - Me.MouseBoxDimension, Me.MouseBoxDimension * 2, Me.MouseBoxDimension * 2)
    End Sub
    Public Function MousePos() As Point
        Return New Point(Me.MouseBox.X + Me.MouseBoxDimension, Me.MouseBox.Y + Me.MouseBoxDimension)
    End Function
    '==================================
    ' Events
    '==================================
    Private Sub Window_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        UpdateMouseBox(e)
    End Sub
    Private Sub Window_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.MouseIsDown = True
    End Sub
    Private Sub Window_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Me.MouseIsDown = False
    End Sub

    '=======================================
    '   Public Procedures/Functions
    '   {All of these are optional to the running of the session}
    '=======================================
    Public Function IsMouseDown() As Boolean
        Return Me.MouseIsDown
    End Function
    Public Sub SetMouseBoxDimension(val As Byte)
        Me.MouseBoxDimension = val
    End Sub
    Public Function GetMouseBox() As Rectangle
        Return Me.MouseBox
    End Function
    Public Function GetMouseBoxDimension() As Byte
        Return Me.MouseBoxDimension
    End Function
    Public Function GetGraphics() As Graphics
        Return Me.g.Graphics
    End Function
    Public Sub EndDrawing()
        Try
            Me.g.Render()
        Catch
            Application.Exit()

        End Try
    End Sub
    Public Sub SetClearColor(c As Color)
        Me.ClearColor = c
    End Sub
    Public Function GetClearColor() As Color
        Return Me.ClearColor
    End Function
End Class
