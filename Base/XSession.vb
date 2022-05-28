Imports System.Drawing
Public Class XSession

    '====================================

    'This class provides the services of:

    '   Management of all objects in the session

    '   Management includes;

    '       - Object updating
    '       - Object deletion
    '       - Allowance of object variance
    '       - Implementation of GraphicsBase

    '   Due to the nature of this class, any class that 
    '   inherits XBase will be able to function through this class.
    '   In order to change any of these objects from outside the session,
    '   A pointer is needed to the object. {cannot be initialised in AddObj(Object)}

    '   This allows the types of objects to include;

    '       -Entities {Of all types}

    '       -Calculators {Classes performing mathmatical operations}

    '       -Graphics {Classes that draw on the screen}

    '====================================
    Public WithEvents Window As XWindow
    Private Running As Boolean
    Private FPS As Short
    Private Containers As XObjHolder
    Private Bounds As Rectangle
    '{will represent borders used by XBase Inheritors}
    '{usually will be the bounds of the window}
    Sub New(FormIn As Form)
        Me.Containers = New XObjHolder
        Me.FPS = 60 '{default}
        Me.Window = New XWindow(FormIn)
        Me.SetBounds(FormIn.DisplayRectangle)
    End Sub
    Public Sub Begin()
        Me.Running = True
        BeginMainLoop()
    End Sub
    Public Sub Halt()
        Me.Running = False
    End Sub
    Private Sub BeginMainLoop()
        Dim LoopTimer As New Stopwatch
        While Me.Running
            LoopTimer.Restart()
            Me.Update()
            Me.Draw()
            Application.DoEvents()
            LoopTimer.Stop()
            TimerTech(LoopTimer)
        End While
    End Sub
    Public Sub Update()
        ObjQueueIteration()
        ObjListIteration()
        WhiteListIteration()
    End Sub
    Private Sub ObjListIteration()
        For i = 0 To Me.Containers.MainList.Count - 1
            Dim Obj As XBase = Me.Containers.MainList(i)
            Obj.Update(Me)
            If Obj.IsSetToDispose Then
                Me.Containers.WhiteList.Add(Obj)
            End If
        Next
    End Sub
    Private Sub WhiteListIteration()
        For i = 0 To Me.Containers.WhiteList.Count - 1
            Dim Obj As XBase = Me.Containers.WhiteList(i)
            Me.Containers.MainList.Remove(Obj)
            NullifyObj(Obj)
        Next
        Me.Containers.WhiteList.Clear()
    End Sub
    Private Sub ObjQueueIteration()
        For i = 0 To Me.Containers.QueueList.Count - 1
            Me.Containers.MainList.Add(Me.Containers.QueueList(0))
            Me.Containers.QueueList.RemoveAt(0)
        Next
    End Sub
    Private Sub TimerTech(ByRef Timer As Stopwatch)
        Dim SleepTime As Integer = (1000 / Me.FPS) - Timer.ElapsedMilliseconds
        If SleepTime > 0 Then
            Threading.Thread.Sleep(SleepTime)
        End If
    End Sub
    Public Sub QueueRelease()
        '{Release all objects in the queue into the main list}
        '{used before looping begins}
        ObjQueueIteration()
    End Sub
    Private Sub NullifyObj(ByRef Obj As XBase)
        Obj = Nothing
    End Sub
    Private Sub Draw()
        Dim g As Graphics = Me.Window.GetGraphics
        g.Clear(Color.White)
        DrawCalls(g)
        Me.Window.EndDrawing()
    End Sub
    Private Sub DrawCalls(ByRef g As Graphics)
        For i = 0 To Me.Containers.MainList.Count - 1
            Dim Obj As XBase = Me.Containers.MainList(i)
            If Obj.IsSetToDraw Then
                Obj.Draw(g)
            End If
        Next
    End Sub
    '=======================================
    '   Public Procedures/Functions
    '   {All of these are optional to the running of the session}
    '=======================================
    Public Sub AddObj(Obj As XBase)
        Me.Containers.QueueList.Add(Obj)
    End Sub
    Public Function GetMatches(Of T)() As List(Of T)
        Return Me.Containers.MainList.OfType(Of T).ToList
    End Function
    Public Function GetBounds() As Rectangle
        Return Me.Bounds
    End Function
    Public Sub SetBounds(ByVal Bounds As Rectangle)
        Me.Bounds = Bounds
    End Sub
    Public Function Centre() As Point
        Return New Point(Me.Bounds.X + (Me.Bounds.Width / 2), Me.Bounds.Y + (Me.Bounds.Height / 2))
    End Function
    Public Function GetObjList() As List(Of XBase)
        Return Me.Containers.MainList
    End Function
    Public Function GetWhiteList() As List(Of XBase)
        Return Me.Containers.WhiteList
    End Function
    Public Function GetObjQueueList() As List(Of XBase)
        Return Me.Containers.QueueList
    End Function
    Public Sub SetFPS(FPS As Short)
        Me.FPS = FPS
    End Sub
    Public Function GetFPS() As Short
        Return Me.FPS
    End Function
End Class
