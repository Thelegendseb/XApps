Imports System.Numerics

Public Class Slider

    Private Control_ As Control

    Private Steps As Integer
    Private TimeDuration_s As Decimal

    Sub New(ControlIn As Control)
        MyBase.New()

        Me.Control_ = ControlIn

        ' // first param between 0-100 smoothness value
        ' // second param time taken in seconds between 1-infinity

        Me.Steps = 100
        Me.TimeDuration_s = 2

    End Sub

    Sub New(ControlIn As Control, Steps_ As Integer, TimeDuration_s_ As Decimal)
        MyBase.New()

        Me.Control_ = ControlIn

        ' // first param between 0-100 smoothness value
        ' // second param time taken in seconds between 1-infinity

        Me.Steps = Steps_
        Me.TimeDuration_s = TimeDuration_s_

    End Sub

    Public Sub SlideIn(StartPos As Vector2, EndPos As Vector2)

        Me.Control_.Left = StartPos.X
        Me.Control_.Top = StartPos.Y

        For i = 0 To Me.Steps - 1

            Dim newval As Vector2 = Vector2.Lerp(StartPos, EndPos, 1 - Eq(i / Me.Steps))

            Me.Control_.Left = newval.X
            Me.Control_.Top = newval.Y

            System.Threading.Thread.Sleep((Me.TimeDuration_s * 1000) / Me.Steps)

            Application.DoEvents()

        Next

        Me.Control_.Left = EndPos.X
        Me.Control_.Top = EndPos.Y

    End Sub
    Public Sub SlideOut(StartPos As Vector2, EndPos As Vector2)

        Me.Control_.Left = EndPos.X
        Me.Control_.Top = EndPos.Y

        For i = 0 To Me.Steps - 1

            Dim newval As Vector2 = Vector2.Lerp(EndPos, StartPos, 1 - Eq(i / Me.Steps))

            Me.Control_.Left = newval.X
            Me.Control_.Top = newval.Y

            System.Threading.Thread.Sleep((Me.TimeDuration_s * 1000) / Me.Steps)

            Application.DoEvents()

        Next

        Me.Control_.Left = StartPos.X
        Me.Control_.Top = StartPos.Y

    End Sub

    Private Function Eq(val As Decimal) As Decimal
        Return 0.5 * Math.Cos(Math.PI * val) + 0.5
    End Function

    ' // ============================

    Public Sub SetSteps(val As Integer)
        Me.Steps = val
    End Sub

    Public Function GetSteps() As Integer
        Return Me.Steps
    End Function
    Public Sub SetTimeDuration_s(val As Decimal)
        Me.TimeDuration_s = val
    End Sub

    Public Function GetTimeDuration_s() As Decimal
        Return Me.TimeDuration_s
    End Function

    Public Sub SetControl(val As Control)
	    Me.Control_ = val
    End Sub

    Public Function GetControl() As Control
    	Return Me.Control_
    End Function

End Class
