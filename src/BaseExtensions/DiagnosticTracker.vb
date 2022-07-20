Imports System.Diagnostics
Public Class DiagnosticTracker

    Inherits XBase

    'This class will provide a way to track performance of the application.

    'Services will include:

    '1. Latency calculations 
    '2. CPU usage 
    '3. Memory usage 
    '4. Number of threads 
    '5. Number of processes 

    Private LastLatency As Double
    Private LastCPUUsage As Byte
    Private LastMemoryUsage As Byte
    Private LastThreadCount As Integer
    Private LastProcessCount As Integer
    Sub New()

    End Sub
    Public Overrides Sub Update(Session As XSession)
        UpdateLatency()
        UpdateCPUUsage()
        UpdateMemoryUsage()
        UpdateThreadCount()
        UpdateProcessCount()
    End Sub
    Private Sub UpdateLatency()

    End Sub
    Private Sub UpdateCPUUsage()

    End Sub
    Private Sub UpdateMemoryUsage()

    End Sub
    Private Sub UpdateThreadCount()

    End Sub
    Private Sub UpdateProcessCount()

    End Sub
    Public Function Latency() As Double
        Return Me.LastLatency
    End Function
    Public Function CPUUsage() As Byte
        Return Me.CPUUsage
    End Function
    Public Function MemoryUsage() As Byte
        Return Me.MemoryUsage
    End Function
    Public Function ThreadCount() As Integer
        Return Me.ThreadCount
    End Function
    Public Function ProcessCount() As Integer
        Return Me.ProcessCount
    End Function

    '==========================================================
    Public Overrides Sub Draw(ByRef g As Drawing.Graphics)
    End Sub
End Class
