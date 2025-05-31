<%@ Page Title="Clientes" Language="vb" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="WebClientes.aspx.vb" Inherits="GestionClientes.WebClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Clientes</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h3 class="mb-0">Lista de Clientes</h3>
            <a href="WebAgregarCliente.aspx" class="btn btn-success">
                <i class="bi bi-plus-circle"></i> Nuevo Cliente
            </a>
        </div>
        <br />
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
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="litClientes" runat="server" ClientIDMode="Static"></asp:Literal>
            </tbody>
        </table>
    </div>
    <asp:HiddenField ID="hfEliminarId" runat="server" />
    <div class="modal fade" id="modalEliminar" tabindex="-1" aria-labelledby="modalEliminarLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white">
                    <h5 class="modal-title" id="modalEliminarLabel">Confirmar Eliminación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body">
                    ¿Estás seguro de que deseas eliminar este cliente?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnEliminarConfirmado" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminarConfirmado_Click" />
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
