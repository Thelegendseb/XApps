Public Class XArt
    Public Shared Sub LoadSingleImageTexture(W As Integer, H As Integer, Texture As Bitmap, ByRef Target As Bitmap)
        Dim ImageInit As New Bitmap(W, H)
        Dim src_rect As New Rectangle(0, 0, Texture.Width, Texture.Height)
        Dim dst_rect As New Rectangle(0, 0, ImageInit.Width, ImageInit.Height)
        Using g As Graphics = Graphics.FromImage(ImageInit)
            g.DrawImage(Texture, dst_rect, src_rect, GraphicsUnit.Pixel)
        End Using
        Target = ImageInit
    End Sub
    Public Shared Sub LoadSingleImageTexture(X As Integer, Y As Integer, W As Integer, H As Integer, Texture As Bitmap, ByRef Target As Bitmap)
        Dim ImageInit As New Bitmap(W, H)
        Dim src_rect As New Rectangle(X, Y, Texture.Width - X, Texture.Height - Y)
        Dim dst_rect As New Rectangle(0, 0, ImageInit.Width, ImageInit.Height)
        Using g As Graphics = Graphics.FromImage(ImageInit)
            g.DrawImage(Texture, dst_rect, src_rect, GraphicsUnit.Pixel)
        End Using
        Target = ImageInit
    End Sub
    Public Shared Function RGBLimitCheck(val As Integer) As Integer
        If val > 255 Then
            Return 255
        ElseIf val < 0 Then
            Return 0
        Else
            Return val
        End If
    End Function
    Public Shared Function GetShaded(val As Color, shade As Integer) As Color
        Return Color.FromArgb(RGBLimitCheck(val.R - shade),
                              RGBLimitCheck(val.G - shade),
                              RGBLimitCheck(val.B - shade))
    End Function
    Public Shared Function GetShaded(val As Brush, shade As Integer) As Brush
        Dim NewPen As New Pen(val)
        Dim Col As Color = NewPen.Color
        NewPen.Dispose()
        Return New SolidBrush(GetShaded(Col, shade))
    End Function
End Class
