Public Class XControl
    Inherits XBase
    Public Event MouseDown(X As Integer, Y As Integer)
    Protected X, Y, Width, Height As Integer
    Public Sub IsValidForClick(MousePos As Point)
        If MousePos.X > Me.X And MousePos.Y > Me.Y And MousePos.X < Me.X +
                Me.Width And MousePos.Y < Me.Y + Me.Height Then
            RaiseEvent MouseDown(MousePos.X, MousePos.Y)
        End If
    End Sub
    Public Function Bounds() As Rectangle
        Return New Rectangle(Me.X - Me.Width / 2, Me.Y - Me.Height / 2, Me.Width * 2, Me.Height * 2)
    End Function
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        Throw New NotImplementedException()
    End Sub
End Class
