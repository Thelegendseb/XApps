Imports System.Numerics
Imports XApps.Math3D
Public Class Shape
    Protected Property Transform As Transform
    Protected Property Vertices As List(Of Vector3)
    Protected Property Faces As List(Of Face)
    Sub New()
        Me.InitializeAttributes()
    End Sub
    Private Sub InitializeAttributes()
        Me.Transform = New Transform
        Me.Vertices = New List(Of Vector3)
        Me.Faces = New List(Of Face)
    End Sub
    ' // Returns a list of points relative to world coord space
    Public Function CallState() As List(Of Vector3)
        Dim CurrentState As New List(Of Vector3)

        ' // Rotate each vertex by the transform and return the new list of points

        For Each Vertex As Vector3 In Me.Vertices

            ' // Apply scale from transform

            Dim StateVertex As New Vector3(Me.Transform.Position.X + (Vertex.X * Me.Transform.Scale.X),
                                           Me.Transform.Position.Y + (Vertex.Y * Me.Transform.Scale.Y),
                                           Me.Transform.Position.Z + (Vertex.Z * Me.Transform.Scale.Z))

            ' Rotation Matrix Multiplication

            If Me.Transform.Rotation.Pitch <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("X", Me.Transform.Rotation.Pitch), StateVertex)
            End If
            If Me.Transform.Rotation.Yaw <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("Y", Me.Transform.Rotation.Yaw), StateVertex)
            End If
            If Me.Transform.Rotation.Roll <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("Z", Me.Transform.Rotation.Roll), StateVertex)
            End If

            ' // Add to CurrentState List

            CurrentState.Add(StateVertex)
        Next
        Return CurrentState
    End Function
    '=============================
    Public Function GetTransform() As Transform
        Return Me.Transform
    End Function
    Public Function GetVertices() As List(Of Vector3)
        Return Me.Vertices
    End Function
    Public Function GetFaces() As List(Of Face)
        Return Me.Faces
    End Function
End Class
