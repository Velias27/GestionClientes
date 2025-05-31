Public Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Username") IsNot Nothing Then
                lblUsuario.Text = Session("Username").ToString()
            Else
                Response.Redirect("WebLogin.aspx")
            End If
        End If
    End Sub
    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Response.Redirect("WebLogin.aspx")
    End Sub
End Class