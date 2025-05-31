Imports System.Data.SqlClient

Public Class WebClientes
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarClientes()
        End If
    End Sub
    Private Sub cargarClientes()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT IdCliente, NombreComercial, Documento, Telefono, Departamento, Municipio, Activo FROM Cliente"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    Dim sb As New StringBuilder()
                    While dr.Read()
                        sb.Append("<tr>")
                        sb.AppendFormat("<td>{0}</td>", dr("IdCliente"))
                        sb.AppendFormat("<td>{0}</td>", dr("NombreComercial"))
                        sb.AppendFormat("<td>{0}</td>", dr("Documento"))
                        sb.AppendFormat("<td>{0}</td>", dr("Telefono"))
                        sb.AppendFormat("<td>{0}</td>", dr("Departamento"))
                        sb.AppendFormat("<td>{0}</td>", dr("Municipio"))
                        sb.AppendFormat("<td>{0}</td>", If(dr("Activo") = "S", "Activo", "Inactivo"))
                        sb.Append("</tr>")
                    End While
                    litClientes.Text = sb.ToString()
                End Using
            End Using
        End Using
    End Sub
End Class