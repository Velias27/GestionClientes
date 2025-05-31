<%@ Page Title="Home" Language="vb" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="GestionClientes.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Home</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center mt-4">
        <div class="col-md-4">
            <div class="card shadow-sm border-0">
                <div class="card-body">
                    <h5 class="card-title">Clientes</h5>
                    <p class="card-text display-6" id="lblCantidadClientes" runat="server">-</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-0">
                <div class="card-body">
                    <h5 class="card-title">Último Movimiento</h5>
                    <p class="card-text display-8" id="lblUltimoMov" runat="server">-</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-0">
                <div class="card-body">
                    <h5 class="card-title">Clientes Activos</h5>
                    <p class="card-text display-6" id="lblClientesActivos" runat="server">-</p>
                </div>
            </div>
        </div>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column text-center" style="min-height: 60vh;">
        <img src="content/img/logo.png" class="img-fluid" alt="Logo" style="max-width: 280px;" />
    </div>
</asp:Content>
