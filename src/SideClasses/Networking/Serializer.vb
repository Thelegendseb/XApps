Imports System.Text.Json
Namespace Networking
    Public Class Serializer
        Public Shared Function Serialize(Of T)(value As T) As Byte()
            Dim response_str As String = JsonSerializer.Serialize(value, GetType(T), New JsonSerializerOptions)
            Return System.Text.Encoding.UTF8.GetBytes(response_str)
        End Function
        Public Shared Function Deserialize(Of T)(data() As Byte) As T
            Dim recieve_str As String = System.Text.Encoding.UTF8.GetString(data)
            recieve_str = recieve_str.Replace(vbNullChar, "")
            Dim response_obj As T = JsonSerializer.Deserialize(recieve_str, GetType(T), New JsonSerializerOptions)
            Return response_obj
        End Function
    End Class

End Namespace