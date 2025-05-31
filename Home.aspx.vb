Imports System.Data.SqlClient

Public Class Home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerCantClientes()
            obtenerClientesActivos()
        End If
    End Sub
    Private Sub obtenerCantClientes()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT COUNT(*) FROM Cliente"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                lblCantidadClientes.InnerText = count.ToString()
            End Using
        End Using
    End Sub
    Private Sub obtenerClientesActivos()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT COUNT(*) FROM Cliente WHERE ACTIVO = 'S'"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                lblClientesActivos.InnerText = count.ToString()
            End Using
        End Using
    End Sub
End Class