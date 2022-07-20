Public Class XMath
    Public Shared Function Distance(p1 As Point, p2 As Point) As Double
        Return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))
    End Function
    Public Shared Function Distance(x1 As Double, y1 As Double, x2 As Double, y2 As Double) As Double
        Return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2))
    End Function
    Public Shared Function IsPrime(n As Integer) As Boolean
        If n = 1 Or n = 2 Then Return False
        If n Mod 2 = 0 Then Return False
        For i As Integer = 3 To Math.Sqrt(n) Step 2
            If n Mod i = 0 Then Return False
        Next
        Return True
    End Function
    Public Shared Function Map(Value As Double,
                         Min As Double,
                         Max As Double,
                         Min2 As Double,
                         Max2 As Double) As Double
        Return (((Value - Min) / (Max - Min)) * (Max2 - Min2)) + Min2
    End Function
End Class
