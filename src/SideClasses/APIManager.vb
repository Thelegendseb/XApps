Imports System.Net
Imports System.Text.Json
Public Class APIManager
    Private Client As WebClient
    Sub New()
        ClientInit()
    End Sub
    ' // Serialize => To Byte Array 
    ' // Deserialize => To Object
    Public Function [Get](Of T)(CALLURL As String) As T
        Dim Result As String = Me.Get(CALLURL)
        Dim FormattedResult As T = JsonSerializer.Deserialize(Of T)(Result)
        Return FormattedResult
    End Function
    Public Function [Get](CALLURL As String) As String
        Return Me.Client.DownloadString(CALLURL)
    End Function
    Public Function MyPublicIP() As String
        Return Me.Get("https://api.my-ip.io/ip")
    End Function
    Private Sub ClientInit()
#Disable Warning SYSLIB0014 ' Type or member is obsolete
        Me.Client = New WebClient
#Enable Warning SYSLIB0014 ' Type or member is obsolete
    End Sub
End Class
