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
            Dim query As String = "
            SELECT
                Idcliente,
                NombreComercial,
                Documento,
                Telefono,
                Activo,
                m.Nombre Municipio,
                d.Nombre Departamento
            FROM cliente c
            INNER JOIN Municipio m on m.IdMunicipio = c.IdMunicipio
            INNER JOIN Departamento d on d.IdDepartamento = m.IdDepartamento"
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
                        sb.AppendFormat("
                        <td>
                            <a href='WebEditarCliente.aspx?id={0}' class='btn btn-sm btn-primary'><i class='bi bi-pencil-square'></i></a>
                            <button type='button' class='btn btn-sm btn-danger ms-1' onclick='confirmarEliminacion({0})'><i class='bi bi-trash'></i></button>
                        </td>", dr("IdCliente"))
                        sb.Append("</tr>")
                    End While
                    litClientes.Text = sb.ToString()
                End Using
            End Using
        End Using
    End Sub
    Protected Sub btnEliminarConfirmado_Click(sender As Object, e As EventArgs)
        Dim idCliente As Integer = Integer.Parse(hfEliminarId.Value)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM Cliente WHERE IdCliente = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", idCliente)
            cmd.ExecuteNonQuery()
        End Using
        Response.Redirect("WebClientes.aspx")
    End Sub
End Class