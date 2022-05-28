Public Class Shapes
    Public Class TwoD

        '===============================
        '  2D Shapes
        '===============================

        ' ALL CLASSES MUST INHERIT TWODBASE

        'These shapes have built in Draw methods.
        'These draw methods are called by the Draw method of the parent class.
        'They do not account for rotation. To draw rotated objects,
        'The BaseExtensions.Renderer.Draw method must be called.

        'Inherited Classes must contain these traces back to the base class's constructors:

        '-----------------
        'Public Sub New()
        '    MyBase.New()
        'End Sub
        'Public Sub New(xin As Double, yin As Double)
        '    MyBase.New(xin, yin)
        'End Sub
        'Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
        '    MyBase.New(xin, yin, widthin, heightin)
        'End Sub
        'Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
        '    MyBase.New(xin, yin, widthin, heightin, thetain)
        'End Sub
        '-----------------
        '===============================
        Public Class TwoDBase
            Inherits XBase
            Protected X, Y, Width, Height, Theta As Double
            Public Overrides Sub Update(Session As XSession)
            End Sub
            Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
                g.DrawRectangle(Drawing.Pens.Black, Me.GetBounds())
            End Sub
            Sub New()
                Me.X = 0
                Me.Y = 0
                Me.Width = 0
                Me.Height = 0
                Me.Theta = 0
            End Sub
            Sub New(xin As Double, yin As Double)
                Me.X = xin
                Me.Y = yin
                Me.Width = 0
                Me.Height = 0
                Me.Theta = 0
            End Sub
            Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
                Me.X = xin
                Me.Y = yin
                Me.Width = widthin
                Me.Height = heightin
                Me.Theta = 0
            End Sub
            Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
                Me.X = xin
                Me.Y = yin
                Me.Width = widthin
                Me.Height = heightin
                Me.Theta = thetain
            End Sub
            '==============================
            '   Public Functions/Procedures
            '==============================
            Public Sub SetX(val As Double)
                Me.X = val
            End Sub
            Public Sub SetY(val As Double)
                Me.Y = val
            End Sub
            Public Sub SetWidth(val As Double)
                Me.Width = val
            End Sub
            Public Sub SetHeight(val As Double)
                Me.Height = val
            End Sub
            Public Sub SetTheta(val As Double)
                Me.Theta = val
            End Sub
            Public Function GetX() As Double
                Return Me.X
            End Function
            Public Function GetY() As Double
                Return Me.Y
            End Function
            Public Function GetWidth() As Double
                Return Me.Width
            End Function
            Public Function GetHeight() As Double
                Return Me.Height
            End Function
            Public Function GetTheta() As Double
                Return Me.Theta
            End Function
            '---------------------------
            Public Sub SetBounds(val As System.Drawing.Rectangle)
                Me.X = val.X - val.Width / 2
                Me.Y = val.Y - val.Height / 2
                Me.Width = val.Width
                Me.Height = val.Height
            End Sub
            Public Function GetBounds() As System.Drawing.Rectangle
                Return New System.Drawing.Rectangle(Me.X - Me.Width / 2, Me.Y - Me.Height / 2, Me.Width, Me.Height)
            End Function
            '---------------------------
            Public Sub StretchHorizontal(ScaleFactor As Double, Optional ReCentre As Boolean = False)
                Me.Width *= ScaleFactor
                If ReCentre Then
                    '  Me.X -= Me.Width / 2
                End If
            End Sub
            Public Sub StretchVertical(ScaleFactor As Double, Optional ReCentre As Boolean = False)
                Me.Height *= ScaleFactor
                If ReCentre Then
                    ' Me.Y -= Me.Height / 2
                End If
            End Sub
        End Class
        Public Class Box
            Inherits TwoDBase
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(xin As Double, yin As Double)
                MyBase.New(xin, yin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
                MyBase.New(xin, yin, widthin, heightin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
                MyBase.New(xin, yin, widthin, heightin, thetain)
            End Sub
            Public Overrides Sub Update(Session As XSession)
            End Sub
            Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
                g.DrawRectangle(Drawing.Pens.Black, Me.GetBounds())
            End Sub
        End Class
        Public Class Ellipse
            Inherits TwoDBase
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(xin As Double, yin As Double)
                MyBase.New(xin, yin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
                MyBase.New(xin, yin, widthin, heightin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
                MyBase.New(xin, yin, widthin, heightin, thetain)
            End Sub
            Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
                g.DrawEllipse(Drawing.Pens.Black, Me.GetBounds())
            End Sub
        End Class
        Public Class Circle
            Inherits TwoDBase
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(xin As Double, yin As Double)
                MyBase.New(xin, yin)
            End Sub
            Public Sub New(xin As Double, yin As Double, radiusin As Double)
                MyBase.New(xin, yin, radiusin, radiusin)
            End Sub
            Public Overrides Sub Update(Session As XSession)
            End Sub
            Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
                g.DrawEllipse(Drawing.Pens.Black, Me.GetBounds())
            End Sub
            Public Sub SetRadius(val As Double)
                Me.Width = val
                Me.Height = val
            End Sub
            Public Function GetRadius() As Double
                Return Me.Width
            End Function
        End Class
        Public Class SpinningBox
            Inherits Box
            Private SpinRate As Decimal
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(xin As Double, yin As Double)
                MyBase.New(xin, yin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
                MyBase.New(xin, yin, widthin, heightin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
                MyBase.New(xin, yin, widthin, heightin, thetain)
            End Sub
            Public Overrides Sub Update(Session As XSession)
                Me.Theta += Me.SpinRate
            End Sub
            Public Sub SetSpinRate(val As Decimal)
                Me.SpinRate = val
            End Sub
            Public Function GetSpinRate() As Decimal
                Return Me.SpinRate
            End Function
        End Class
        Public Class SpinningEllipse
            Inherits Ellipse
            Private SpinRate As Decimal
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(xin As Double, yin As Double)
                MyBase.New(xin, yin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double)
                MyBase.New(xin, yin, widthin, heightin)
            End Sub
            Public Sub New(xin As Double, yin As Double, widthin As Double, heightin As Double, thetain As Double)
                MyBase.New(xin, yin, widthin, heightin, thetain)
            End Sub
            Public Overrides Sub Update(Session As XSession)
                Me.Theta += Me.SpinRate
            End Sub
            Public Sub SetSpinRate(val As Decimal)
                Me.SpinRate = val
            End Sub
            Public Function GetSpinRate() As Decimal
                Return Me.SpinRate
            End Function
        End Class
    End Class

    Public Class ThreeD

        '===============================
        '  3D Shapes
        '===============================

    End Class

End Class
