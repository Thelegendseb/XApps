Public Class XButton
    Inherits XControl
    Private ColorDefualt As Color
    Private ColorHover As Color
    Private ColorBorder As Color
    Private Hovering As Boolean
    Private BorderWidth As Integer
    Private Text As String
    Sub New(x As Integer, y As Integer, w As Integer, h As Integer,
            C1 As Color, C2 As Color, Border As Color, Optional B_Width As Integer = 5)
        MyBase.New(x, y, w, h)

        Me.ColorDefualt = C1
        Me.ColorHover = C2
        Me.ColorBorder = Border
        Me.BorderWidth = B_Width

        Me.SetUpdateStatus(True)
        Me.SetDrawStatus(True)
    End Sub
    Public Sub SetBounds(Bounds As Rectangle)
        Me.Bounds = Bounds
    End Sub
    Public Function GetBounds() As Rectangle
        Return Me.Bounds
    End Function
    Public Sub SetText(val As String)
        Me.Text = val
    End Sub
    Public Function GetText() As String
        Return Me.Text
    End Function
    Public Overrides Sub Update(Session As XSession)

        If Me.IsValidForClick(Session.Window.MousePos) Then 'Hovering
            Me.Hovering = True
        Else
            Me.Hovering = False
        End If

    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        Dim Br As SolidBrush
        Dim P As New Pen(Me.ColorBorder, Me.BorderWidth)
        Dim F As New Font(FontFamily.GenericSerif, CSng((Me.Bounds.Width + Me.Bounds.Height) / 12), FontStyle.Bold)

        If Me.Hovering Then
            Br = New SolidBrush(Me.ColorHover)
        Else
            Br = New SolidBrush(Me.ColorDefualt)
        End If

        g.FillRectangle(Br, Me.Bounds)
        g.DrawRectangle(P, Me.Bounds)

        If Me.Text <> "" Then
            Dim S As SizeF = g.MeasureString(Me.Text, F)
            Br.Color = Me.ColorBorder
            Dim x As Integer = Me.Bounds.X + (Me.Bounds.Width / 2) - (S.Width / 2)
            Dim y As Integer = Me.Bounds.Y + (Me.Bounds.Height / 2) - (S.Height / 2)
            g.DrawString(Me.Text, F, Br, x, y)
        End If

        F.Dispose()
        Br.Dispose()
        P.Dispose()
    End Sub
End Class
