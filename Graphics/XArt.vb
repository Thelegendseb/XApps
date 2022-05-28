Public Class XArt

    Public Shared Function LimitCheck(val As Integer) As Integer
        If val > 255 Then
            Return 255
        ElseIf val < 0 Then
            Return 0
        Else
            Return val
        End If
    End Function

    Public Shared Function GetShaded(val As Color, shade As Integer) As Color
        Return Color.FromArgb(LimitCheck(val.R - shade),
                              LimitCheck(val.G - shade),
                              LimitCheck(val.B - shade))
    End Function
    Public Shared Function GetShaded(val As Brush, shade As Integer) As Brush
        Dim NewPen As New Pen(val)
        Dim Col As Color = NewPen.Color
        NewPen.Dispose()
        Return New SolidBrush(GetShaded(Col, shade))
    End Function
End Class
