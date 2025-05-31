Imports System.Data.SqlClient

Public Class Home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerCantClientes()
            obtenerClientesActivos()
            obtenerUltimoMov()
        End If
    End Sub
    Private Sub obtenerCantClientes()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT COUNT(*) FROM Cliente WHERE Eliminado = 'N'"
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
            Dim query As String = "SELECT COUNT(*) FROM Cliente WHERE Activo = 'S' AND Eliminado  = 'N'"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                lblClientesActivos.InnerText = count.ToString()
            End Using
        End Using
    End Sub
    Private Sub obtenerUltimoMov()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            Dim query As String = "SELECT TOP 1 Operacion, c.NombreComercial, u.Username, Fecha FROM BitacoraAccion ba
            INNER JOIN Cliente c ON c.IdCliente = ba.IdCliente
            INNER JOIN Usuario u ON u.IdUsuario = ba.IdUsuario
            ORDER BY Fecha DESC"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        lblUltimoMov.InnerText = $"Usuario {dr("Username").ToString()} ejecuta: {dr("Operacion").ToString()}  a Cliente {dr("NombreComercial")} el {dr("Fecha")}"
                    Else
                        lblUltimoMov.InnerText = "Sin movimientos"
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class