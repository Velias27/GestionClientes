<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebLogin.aspx.vb" Inherits="GestionClientes.WebLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/x-icon" href="content/img/icono.ico" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.22.0/dist/sweetalert2.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link rel="stylesheet" href="content/css/login.css" />
</head>
<body class="d-flex flex-column min-vh-100 bg-light">
    <form runat="server" class="flex-grow-1 d-flex align-items-center">
        <div class="container">
            <div class="row justify-content-center align-items-center g-4">
                <!-- Imagen -->
                <div class="col-12 col-md-5 text-center">
                    <img src="content/img/logo.png" class="img-fluid" alt="Logo"
                        style="max-width: 280px; height: auto;" />
                </div>
                <!-- Formulario -->
                <div class="col-12 col-md-6">
                    <div class="card shadow-sm border-0">
                        <div class="card-body p-4">
                            <h4 class="mb-4 text-center">Inicio de Sesión</h4>
                            <div class="mb-3">
                                <label for="txtUsername" class="form-label">Username</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg" Text="LOGIN" OnClick="btnLogin_Click" />
                            </div>
                            <br />
                            <!-- Alerta -->
                            <asp:Panel ID="pnlAlerta" runat="server" Visible="False" CssClass="alert alert-danger" role="alert">
                                Usuario o contraseña incorrectos.
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- Footer -->
    <footer class="bg-primary text-white text-center py-3 w-100">
        <div class="container">
            <small>&copy; 2025 Victor Elías. Todos los derechos reservados.</small>
        </div>
    </footer>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
