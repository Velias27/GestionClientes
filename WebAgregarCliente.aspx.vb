Imports System.Data.SqlClient
Public Class WebAgregarCliente
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDepartamentos()
            CargarMunicipios(1)
        End If
    End Sub
    Private Sub CargarDepartamentos()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString

        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT IdDepartamento, Nombre FROM Departamento ORDER BY Nombre", conn)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                ddlDepartamento.Items.Clear()
                While dr.Read()
                    ddlDepartamento.Items.Add(New ListItem(dr("Nombre").ToString(), dr("IdDepartamento").ToString()))
                End While
            End Using
        End Using
    End Sub
    Protected Sub ddlDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim idDepartamento As Integer
        If Integer.TryParse(ddlDepartamento.SelectedValue, idDepartamento) Then
            CargarMunicipios(idDepartamento)
        Else
            ddlMunicipio.Items.Clear()
        End If
    End Sub
    Private Sub CargarMunicipios(idDepartamento As Integer)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT IdMunicipio, Nombre FROM Municipio WHERE IdDepartamento = @Id ORDER BY Nombre", conn)
            cmd.Parameters.AddWithValue("@Id", idDepartamento)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                ddlMunicipio.Items.Clear()
                While dr.Read()
                    ddlMunicipio.Items.Add(New ListItem(dr("Nombre").ToString(), dr("IdMunicipio").ToString()))
                End While
            End Using
        End Using
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "INSERT INTO Cliente (NombreComercial, RazonSocial, Documento, Telefono, CorreoElectronico, Direccion, IdMunicipio) 
                               VALUES (@NombreComercial, @RazonSocial, @Documento, @Telefono, @CorreoElectronico, @Direccion, @IdMunicipio)"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NombreComercial", inputNombreComercial.Value)
                cmd.Parameters.AddWithValue("@RazonSocial", inputRazonSocial.Value)
                cmd.Parameters.AddWithValue("@Documento", inputDocumento.Value)
                cmd.Parameters.AddWithValue("@Telefono", inputTelefono.Value)
                cmd.Parameters.AddWithValue("@CorreoElectronico", inputCorreo.Value)
                cmd.Parameters.AddWithValue("@Direccion", inputDireccion.Value)
                cmd.Parameters.AddWithValue("@IdMunicipio", 1)

                cmd.ExecuteNonQuery()
            End Using
        End Using
        Response.Redirect("WebClientes.aspx")
    End Sub
End Class