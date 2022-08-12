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

            Dim StateVertex As New Vector3((Vertex.X * Me.GetTransform.GetScale.X),
                                            (Vertex.Y * Me.GetTransform.GetScale.Y),
                                            (Vertex.Z * Me.GetTransform.GetScale.Z))

            ' Rotation Matrix Multiplication

            If Me.Transform.GetRotation.Pitch <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("X", Me.Transform.GetRotation.Pitch), StateVertex)
            End If
            If Me.Transform.GetRotation.Yaw <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("Y", Me.Transform.GetRotation.Yaw), StateVertex)
            End If
            If Me.Transform.GetRotation.Roll <> 0 Then
                StateVertex = Matrix.Multiply(Matrix.Type("Z", Me.Transform.GetRotation.Roll), StateVertex)
            End If

            ' // Add Position

            StateVertex.X += Me.Transform.GetPosition.X
            StateVertex.Y += Me.Transform.GetPosition.Y
            StateVertex.Z += Me.Transform.GetPosition.Z

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
