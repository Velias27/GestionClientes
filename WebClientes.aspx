<%@ Page Title="Clientes" Language="vb" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="WebClientes.aspx.vb" Inherits="GestionClientes.WebClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Clientes</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 class="mb-4">Lista de Clientes</h3>
        <table id="tblClientes" class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre Comercial</th>
                    <th>Documento</th>
                    <th>Teléfono</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Estado</th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="litClientes" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>

</asp:Content>

