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
    'Funcion para cargar departamentos de la bd
    Private Sub CargarDepartamentos()
        Try
            ddlDepartamento.Items.Clear()
            ddlDepartamento.Items.AddRange(UtilidadesBD.ObtenerDepartamentos().ToArray())
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "
        Swal.fire({ icon: 'error', title: 'Error', text: 'No se pudo cargar la información de los departamentos.' });", True)
        End Try
    End Sub
    'Evento cuando cambia de Departamento, manda a llamar los municipios que corresponden a ese departamento
    Protected Sub ddlDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim idDepartamento As Integer
        If Integer.TryParse(ddlDepartamento.SelectedValue, idDepartamento) Then
            CargarMunicipios(idDepartamento)
        Else
            ddlMunicipio.Items.Clear()
        End If
    End Sub
    'Los municipios son cargados de acuerdo al departamento seleccionado
    Private Sub CargarMunicipios(idDepartamento As Integer)
        Try
            ddlMunicipio.Items.Clear()
            ddlMunicipio.Items.AddRange(UtilidadesBD.ObtenerMunicipios(idDepartamento).ToArray())
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "
        Swal.fire({ icon: 'error', title: 'Error', text: 'No se pudo cargar la información de los municipios.' });", True)
        End Try
    End Sub
    'Trae la información del cliente seleccionado
    Private Sub CargarCliente(idCliente As Integer)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Try
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
        Catch ex As Exception
            ' Muestra alerta de error
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se pudo cargar la información del cliente seleccionado.'
            });", True)
        End Try
    End Sub
    'Evento click del boton Guardar
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim idCliente As Integer = Integer.Parse(Request("id"))
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Try
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
            'Si todo correcto manda sweet alert por javascript
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alerta", "
            Swal.fire({
                icon: 'success',
                title: '¡Cliente modificado!',
                text: 'El cliente fue modificado correctamente.',
                confirmButtonText: 'Aceptar'
            }).then(() => {
                window.location.href = 'WebClientes.aspx';
            });", True)
        Catch ex As Exception
            ' Muestra alerta de error
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se pudo guardar los cambios del cliente.'
            });", True)
        End Try
    End Sub
End Class