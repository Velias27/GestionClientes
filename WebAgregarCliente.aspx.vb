Imports System.Data.SqlClient
Public Class WebAgregarCliente
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDepartamentos()
            CargarMunicipios(1)
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
    'Evento click del boton guardar
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Verifica los validadores en Cliente
        If Not Page.IsValid Then
            Exit Sub
        End If
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim query As String = "
                    INSERT INTO Cliente (NombreComercial, RazonSocial, Documento, Telefono, CorreoElectronico, Direccion, IdMunicipio)
                    VALUES (@NombreComercial, @RazonSocial, @Documento, @Telefono, @CorreoElectronico, @Direccion, @IdMunicipio);
                    SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@NombreComercial", inputNombreComercial.Value)
                    cmd.Parameters.AddWithValue("@RazonSocial", inputRazonSocial.Value)
                    cmd.Parameters.AddWithValue("@Documento", inputDocumento.Value)
                    cmd.Parameters.AddWithValue("@Telefono", inputTelefono.Value)
                    cmd.Parameters.AddWithValue("@CorreoElectronico", inputCorreo.Value)
                    cmd.Parameters.AddWithValue("@Direccion", inputDireccion.Value)
                    cmd.Parameters.AddWithValue("@IdMunicipio", Integer.Parse(ddlMunicipio.SelectedValue))
                    'Ejecutar y obtener el ID insertado
                    Dim idClienteNuevo As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    'Guardar bitácora
                    Dim idUsuario As Integer = Session("UserId")
                    UtilidadesBD.guardarBitacora("AGREGAR", idClienteNuevo, idUsuario)
                End Using
            End Using
            'Si todo correcto manda sweet alert por javascript
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alerta", "
                Swal.fire({
                    icon: 'success',
                    title: '¡Cliente agregado!',
                    text: 'El cliente fue agregado correctamente.',
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
                    text: 'No se pudo guardar el registro.'
                });", True)
        End Try
    End Sub
End Class