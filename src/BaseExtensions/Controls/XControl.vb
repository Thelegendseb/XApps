Public MustInherit Class XControl
    Inherits XBase
    Protected Bounds As Rectangle
    Protected MouseHover As Boolean
    Public Event MouseDown(x As Integer, y As Integer)
    Sub New(x As Integer, y As Integer, width As Integer, height As Integer)
        Me.Bounds = New Rectangle(x, y, width, height)
    End Sub
    ' ==========================
    Public Function IsValidForClick(MousePos As Point) As Boolean
        If (MousePos.X > Me.Bounds.X And MousePos.X < Me.Bounds.X + Me.Bounds.Width) And
                (MousePos.Y > Me.Bounds.Y And MousePos.Y < Me.Bounds.Y + Me.Bounds.Height) Then
            Return True
        End If
        Return False
    End Function
    Public Sub TriggerMouseDown(P As Point)
        RaiseEvent MouseDown(P.X, P.Y)
    End Sub
End Class
