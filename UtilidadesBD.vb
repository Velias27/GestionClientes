Imports System.Data.SqlClient
Public Class UtilidadesBD
    Public Shared Function ObtenerDepartamentos() As List(Of ListItem)
        Dim lista As New List(Of ListItem)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT IdDepartamento, Nombre FROM Departamento ORDER BY Nombre", conn)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    lista.Add(New ListItem(dr("Nombre").ToString(), dr("IdDepartamento").ToString()))
                End While
            End Using
        End Using
        Return lista
    End Function
    Public Shared Function ObtenerMunicipios(idDepartamento As Integer) As List(Of ListItem)
        Dim lista As New List(Of ListItem)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT IdMunicipio, Nombre FROM Municipio WHERE IdDepartamento = @Id ORDER BY Nombre", conn)
            cmd.Parameters.AddWithValue("@Id", idDepartamento)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    lista.Add(New ListItem(dr("Nombre").ToString(), dr("IdMunicipio").ToString()))
                End While
            End Using
        End Using
        Return lista
    End Function
    Public Shared Sub guardarBitacora(operacion As String, idCliente As Integer, idUsario As Integer)
        Dim lista As New List(Of ListItem)
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "INSERT INTO BitacoraAccion (Operacion, IdCliente, IdUsuario) 
                               VALUES (@Operacion, @IdCliente, @IdUsuario)"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Operacion", operacion)
                cmd.Parameters.AddWithValue("@IdCliente", idCliente)
                cmd.Parameters.AddWithValue("@IdUsuario", idUsario)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
