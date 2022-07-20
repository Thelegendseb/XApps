Public Class Vector
    Public Property X As Double
    Public Property Y As Double
    Sub New()
        Me.X = 0
        Me.Y = 0
    End Sub
    Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub
    Public Sub SetMag(newmag As Double)
        Dim firstmag As Double = Me.Magnitude
        Me.X = Me.X * newmag / firstmag
        Me.Y = Me.Y * newmag / firstmag
    End Sub
    Public Function Magnitude() As Double
        Return Math.Sqrt(Me.X * Me.X + Me.Y * Me.Y)
    End Function
    Public Function Normalize() As Vector
        Dim len As Double = Me.Magnitude
        Return New Vector(Me.X / len, Me.Y / len)
    End Function
    Public Function Distance(v1 As Vector) As Double
        Dim dx As Double = v1.X - Me.X
        Dim dy As Double = v1.Y - Me.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function
    Public Shared Function Distance(v1 As Vector, v2 As Vector) As Double
        Dim dx As Double = v1.X - v2.X
        Dim dy As Double = v1.Y - v2.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function
    Public Shared Function Convert(v1 As Double) As Vector
        Return New Vector(v1, v1)
    End Function
    Public Shared Function DotProduct(v1 As Vector, v2 As Vector) As Double
        Return v1.X * v2.X + v1.Y * v2.Y
    End Function
    Public Function DotProduct(v1 As Vector) As Double
        Return Me.X * v1.X + Me.Y * v1.Y
    End Function
    Public Function Rotate(theta As Double) As Vector
        Dim Old As Vector = Me
        Dim Mid As Vector = Midpoint()
        Dim NewX As Double = Math.Cos(theta) * (Old.X - Mid.X) - Math.Sin(theta) * (Old.Y - Mid.Y) + Mid.X
        Dim NewY As Double = Math.Sin(theta) * (Old.X - Mid.X) + Math.Cos(theta) * (Old.Y - Mid.Y) + Mid.Y
        Return New Vector(NewX, NewY)
    End Function
    Public Function Midpoint() As Vector
        Return New Vector(Me.X / 2, Me.Y / 2)
    End Function
    Public Function MidPoint(v1 As Vector) As Vector
        Return New Vector((Me.X + v1.X) / 2, (Me.Y + v1.Y) / 2)
    End Function
    Public Shared Function MidPoint(v1 As Vector, v2 As Vector) As Vector
        Return New Vector((v1.X + v2.X) / 2, (v1.Y + v2.Y) / 2)
    End Function
    Public Shared Function MidPoint(VArr() As Vector) As Vector
        Dim x As Double = 0
        Dim y As Double = 0
        For Each v In VArr
            x += v.X
            y += v.Y
        Next
        Return New Vector(x / VArr.Length, y / VArr.Length)
    End Function
    Public Shared Function FromPoint(PointIn As Point) As Vector
        Return New Vector(PointIn.X, PointIn.Y)
    End Function
    Public Function Unit() As Vector
        Dim len As Double = Me.Magnitude
        Return New Vector(Me.X / len, Me.Y / len)
    End Function
    Public ReadOnly Property ToPointF() As PointF
        Get
            Return New PointF(CSng(Me.X), CSng(Me.Y))
        End Get
    End Property
    Public Shared ReadOnly Property Zero As Vector
        Get
            Return New Vector(0, 0)
        End Get
    End Property
    Public Shared ReadOnly Property Inverse As Vector
        Get
            Return New Vector(-1, -1)
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return String.Format("[{0},{1}]", Me.X, Me.Y)
    End Function
    'Method Operators {Scalar and Vector inclusive}
    Public Sub Add(v1 As Vector)
        Me.X += v1.X
        Me.Y += v1.Y
    End Sub
    Public Sub Subtract(v1 As Vector)
        Me.X -= v1.X
        Me.Y -= v1.Y
    End Sub
    Public Sub Multiply(v1 As Vector)
        Me.X *= v1.X
        Me.Y *= v1.Y
    End Sub
    Public Sub Divide(v1 As Vector)
        Me.X /= v1.X
        Me.Y /= v1.Y
    End Sub
    '===========================================
    'Scalar Operators
    Public Sub Add(s1 As Double)
        Me.X += s1
        Me.Y += s1
    End Sub
    Public Sub Subtract(s1 As Double)
        Me.X -= s1
        Me.Y -= s1
    End Sub
    Public Sub Multiply(s1 As Double)
        Me.X *= s1
        Me.Y *= s1
    End Sub
    Public Sub Divide(s1 As Double)
        Me.X /= s1
        Me.Y /= s1
    End Sub
    'Public Shared Operators {Scalar and Vector inclusive}
    Public Shared Operator +(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X + v2.X, v1.Y + v2.Y)
    End Operator

    Public Shared Operator -(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X - v2.X, v1.Y - v2.Y)
    End Operator

    Public Shared Operator *(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X * v2.X, v1.Y * v2.Y)
    End Operator

    Public Shared Operator /(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X / v2.X, v1.Y / v2.Y)
    End Operator
    '==========================================================================
    'Scalar Operators
    Public Shared Operator +(ByVal v1 As Vector, ByVal v2 As Double) As Vector
        Return New Vector(v1.X + v2, v1.Y + v2)
    End Operator
    Public Shared Operator -(ByVal v1 As Vector, ByVal v2 As Double) As Vector
        Return New Vector(v1.X - v2, v1.Y - v2)
    End Operator
    Public Shared Operator *(ByVal v1 As Vector, ByVal v2 As Double) As Vector
        Return New Vector(v1.X * v2, v1.Y * v2)
    End Operator
    Public Shared Operator /(ByVal v1 As Vector, ByVal v2 As Double) As Vector
        Return New Vector(v1.X / v2, v1.Y / v2)
    End Operator
End Class

