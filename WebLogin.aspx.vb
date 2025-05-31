Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class WebLogin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim hashedPassword As String = GetSHA256(password)

        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT COUNT(*) FROM Usuario WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", hashedPassword)

                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If count = 1 Then
                    Session("Username") = username
                    Response.Redirect("Home.aspx")
                Else
                    pnlAlerta.Visible = True
                End If
            End Using
        End Using
    End Sub
    Private Function GetSHA256(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim sb As New StringBuilder()
            For Each b As Byte In hash
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function
End Class