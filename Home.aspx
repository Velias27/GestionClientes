<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="GestionClientes.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/x-icon" href="content/img/icono.ico" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="content/css/style.css" />
</head>
<body class="d-flex flex-column min-vh-100 bg-light">
    <form runat="server">
        <header class="p-3 bg-dark text-white">
            <div class="container">
                <div class="d-flex flex-wrap align-items-center justify-content-between">
                    <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                        <li><a href="#" class="nav-link px-2 text-secondary">Home</a></li>
                        <li><a href="#" class="nav-link px-2 text-white">Clientes</a></li>
                    </ul>

                    <div class="d-flex align-items-center">
                        <span class="me-3">Usuario: 
                            <asp:Label ID="lblUsuario" runat="server" CssClass="fw-bold text-warning"></asp:Label>
                        </span>
                        <span class="clock-widget" id="horaActual"></span>
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-warning ms-3" OnClick="btnCerrarSesion_Click" />
                    </div>
                </div>
            </div>
        </header>
    </form>

    <script>
        function actualizarHora() {
            const reloj = document.getElementById("horaActual");
            const ahora = new Date();
            reloj.textContent = ahora.toLocaleTimeString();
        }
        setInterval(actualizarHora, 1000);
        actualizarHora();
    </script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
