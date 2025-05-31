Imports System.Data.SqlClient

Public Class WebEditarCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("id")) Then
                Dim idCliente As Integer = Integer.Parse(Request("id"))
                CargarDepartamentos()
                CargarCliente(idCliente)
            Else
                Response.Redirect("WebClientes.aspx")
            End If
        End If
    End Sub
    Private Sub CargarCliente(idCliente As Integer)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim cmd As New SqlCommand("
            SELECT
                Idcliente,
                NombreComercial,
                RazonSocial,
                Documento,
                Telefono,
                CorreoElectronico,
                Direccion,
                Activo,
                m.IdMunicipio,
                m.Nombre Municipio,
                d.IdDepartamento,
                d.Nombre Departamento
            FROM cliente c
            INNER JOIN Municipio m on m.IdMunicipio = c.IdMunicipio
            INNER JOIN Departamento d on d.IdDepartamento = m.IdDepartamento
            WHERE IdCliente = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", idCliente)

            Using dr As SqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    lblTitulo.InnerText = "Edición de cliente No. " & dr("IdCliente").ToString()
                    inputNombreComercial.Value = dr("NombreComercial").ToString()
                    inputRazonSocial.Value = dr("RazonSocial").ToString()
                    inputDocumento.Value = dr("Documento").ToString()
                    inputTelefono.Value = dr("Telefono").ToString()
                    inputCorreo.Value = dr("CorreoElectronico").ToString()
                    inputDireccion.Value = dr("Direccion").ToString()
                    ddlDepartamento.SelectedValue = dr("IdDepartamento").ToString()
                    CargarMunicipios(dr("IdDepartamento").ToString())
                    ddlMunicipio.SelectedValue = dr("IdMunicipio").ToString()
                    inputActivo.Checked = If(dr("Activo").ToString() = "S", True, False)
                End If
            End Using
        End Using
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

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim idCliente As Integer = Integer.Parse(Request("id"))

        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim cmd As New SqlCommand("
            UPDATE Cliente SET 
                NombreComercial = @NombreComercial,
                RazonSocial = @RazonSocial,
                Documento = @Documento,
                Telefono = @Telefono,
                CorreoElectronico = @Correo,
                Direccion = @Direccion,
                Activo = @Activo,
                IdMunicipio = @IdMunicipio
            WHERE IdCliente = @IdCliente", conn)

            cmd.Parameters.AddWithValue("@IdCliente", idCliente)
            cmd.Parameters.AddWithValue("@NombreComercial", inputNombreComercial.Value)
            cmd.Parameters.AddWithValue("@RazonSocial", inputRazonSocial.Value)
            cmd.Parameters.AddWithValue("@Documento", inputDocumento.Value)
            cmd.Parameters.AddWithValue("@Telefono", inputTelefono.Value)
            cmd.Parameters.AddWithValue("@Correo", inputCorreo.Value)
            cmd.Parameters.AddWithValue("@Direccion", inputDireccion.Value)
            cmd.Parameters.AddWithValue("@Activo", If(inputActivo.Checked, "S", "N"))
            cmd.Parameters.AddWithValue("@IdMunicipio", Integer.Parse(ddlMunicipio.SelectedValue))

            cmd.ExecuteNonQuery()
        End Using

        ' Redireccionar o mostrar mensaje
        Response.Redirect("WebClientes.aspx")
    End Sub
End Class