Public Class Face
    Public VertexIndexs() As Integer
    Sub New(ByVal ArrIn() As Integer)
        If ArrIn.Length <= 2 Then Throw New Exception("Face must have more than 3 vertices")
        Me.VertexIndexs = ArrIn
    End Sub
    Public Sub Assign(ByVal ArrIn() As Integer)
        If ArrIn.Length <= 2 Then Throw New Exception("Face must have more than 3 vertices")
        Me.VertexIndexs = ArrIn
    End Sub
End Class
