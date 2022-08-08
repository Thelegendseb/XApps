
Namespace Shapes
    Namespace TwoD

        '===============================
        '  2D Shapes
        '===============================

        ' ALL CLASSES MUST INHERIT TWODBASE

        'These Shapes have built in Draw methods.
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
            Public Overridable Sub SetX(val As Double)
                Me.X = val
            End Sub
            Public Overridable Sub SetY(val As Double)
                Me.Y = val
            End Sub
            Public Overridable Sub SetWidth(val As Double)
                Me.Width = val
            End Sub
            Public Overridable Sub SetHeight(val As Double)
                Me.Height = val
            End Sub
            Public Overridable Sub SetTheta(val As Double)
                Me.Theta = val
            End Sub
            Public Overridable Function GetX() As Double
                Return Me.X
            End Function
            Public Overridable Function GetY() As Double
                Return Me.Y
            End Function
            Public Overridable Function GetWidth() As Double
                Return Me.Width
            End Function
            Public Overridable Function GetHeight() As Double
                Return Me.Height
            End Function
            Public Overridable Function GetTheta() As Double
                Return Me.Theta
            End Function
            '---------------------------
            Public Overridable Sub SetBounds(val As System.Drawing.Rectangle)
                Me.X = val.X - val.Width / 2
                Me.Y = val.Y - val.Height / 2
                Me.Width = val.Width
                Me.Height = val.Height
            End Sub
            Public Overridable Function GetBounds() As System.Drawing.Rectangle
                Return New System.Drawing.Rectangle(Me.X - Me.Width / 2, Me.Y - Me.Height / 2, Me.Width, Me.Height)
            End Function
            '---------------------------
            Public Overridable Sub StretchHorizontal(ScaleFactor As Double, Optional ReCentre As Boolean = False)
                Me.Width *= ScaleFactor
                If ReCentre Then
                    '  Me.X -= Me.Width / 2
                End If
            End Sub
            Public Overridable Sub StretchVertical(ScaleFactor As Double, Optional ReCentre As Boolean = False)
                Me.Height *= ScaleFactor
                If ReCentre Then
                    ' Me.Y -= Me.Height / 2
                End If
            End Sub
        End Class
        Public Class Message
            Inherits TwoDBase
            Private Font As FontFamily
            Private FontStyle As FontStyle
            Private Size As Integer
            Private Text As String
            Private Brush As Brush
            Private Shadow As Boolean
            Private SpinRate As Double
            Sub New()
                Me.Text = ""
                Init()
            End Sub
            Sub New(text As String)
                Me.Text = text
                Init()
            End Sub
            Private Sub Init()
                Me.Font = FontFamily.GenericSansSerif
                Me.FontStyle = FontStyle.Regular
                Me.Brush = Brushes.Black
                Me.Size = 12
                Me.X = 0
                Me.Y = 0
                Me.SpinRate = 0
            End Sub
            Public Overrides Sub Update(Session As XSession)
                Me.Theta += Me.SpinRate
            End Sub
            Public Overrides Sub Draw(ByRef g As Graphics)
                Dim NewFont As New Font(Me.Font, Me.Size, Me.FontStyle)
                If Me.Shadow Then
                    Dim UnderSize As Integer = Me.Size / 100
                    If UnderSize < 3 Then UnderSize = 3
                    Dim Br As SolidBrush = XArt.GetShaded(Me.Brush, 20)
                    g.DrawString(Me.Text, NewFont, Br, (Me.X - Me.GetWidth / 2) + UnderSize, (Me.Y - Me.GetHeight / 2) + UnderSize)
                    Br.Dispose()
                End If
                g.DrawString(Me.Text, NewFont, Me.Brush, Me.X - Me.GetWidth / 2, Me.Y - Me.GetHeight / 2)
                NewFont.Dispose()
            End Sub
            Public Overrides Function GetWidth() As Double
                Dim NewFont As New Font(Me.Font, Me.Size, Me.FontStyle)
                Dim textSize As Size = TextRenderer.MeasureText(Me.Text, NewFont)
                NewFont.Dispose()
                Return textSize.Width
            End Function
            Public Overrides Function GetHeight() As Double
                Dim NewFont As New Font(Me.Font, Me.Size, Me.FontStyle)
                Dim textSize As Size = TextRenderer.MeasureText(Me.Text, NewFont)
                NewFont.Dispose()
                Return textSize.Height
            End Function
            Public Function GetFont() As FontFamily
                Return Me.Font
            End Function
            Public Sub SetFont(Font As FontFamily)
                Me.Font = Font
            End Sub
            Public Function GetFontStyle() As FontStyle
                Return Me.FontStyle
            End Function
            Public Sub SetFontStyle(FontStyle As FontStyle)
                Me.FontStyle = FontStyle
            End Sub
            Public Function GetText() As String
                Return Me.Text
            End Function
            Public Sub SetText(Text As String)
                Me.Text = Text
            End Sub
            Public Function GetBrush() As Brush
                Return Me.Brush
            End Function
            Public Sub SetBrush(Brush As Brush)
                Me.Brush = Brush
            End Sub
            Public Function GetSize() As Integer
                Return Me.Size
            End Function
            Public Sub SetSize(Size As Integer)
                Me.Size = Size
            End Sub
            Public Function GetShadow() As Boolean
                Return Me.Shadow
            End Function
            Public Sub SetShadow(Shadow As Boolean)
                Me.Shadow = Shadow
            End Sub
            Public Function GetSpinRate() As Double
                Return Me.SpinRate
            End Function
            Public Sub SetSpinRate(SpinRate As Double)
                Me.SpinRate = SpinRate
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
        Public Class Triangle_Isosceles
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

            'overrides the draw method to draw a triangle
            'override the draw method and draw a triangle
            Public Overrides Sub Draw(ByRef g As Graphics)

                Dim PointArray(2) As Point
                PointArray(0) = New Point(Me.X, Me.Y + Me.Height / 2)
                PointArray(1) = New Point(Me.X - Me.Width / 2, Me.Y - Me.Height / 2)
                PointArray(2) = New Point(Me.X + Me.Width / 2, Me.Y - Me.Height / 2)
                g.DrawPolygon(Pens.Black, PointArray)

            End Sub
            Public Function GetPointArray() As Point()
                Dim PointArray(2) As Point
                PointArray(0) = New Point(Me.X, Me.Y + Me.Height / 2)
                PointArray(1) = New Point(Me.X - Me.Width / 2, Me.Y - Me.Height / 2)
                PointArray(2) = New Point(Me.X + Me.Width / 2, Me.Y - Me.Height / 2)
                Return PointArray
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
    End Namespace
    Namespace ThreeD

        '===============================
        '  3D Shapes
        '===============================

    End Namespace

End Namespace
