<%@ Page Title="Editar Cliente" Language="vb" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="WebEditarCliente.aspx.vb" Inherits="GestionClientes.WebEditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Editar Cliente</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 id="lblTitulo" runat="server" class="mb-4">Edición de cliente No. </h3>

        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputNombreComercial" class="form-label">Nombre Comercial</label>
                <input type="text" class="form-control" id="inputNombreComercial" runat="server" />
            </div>
            <div class="col-md-6 mb-3">
                <label for="inputRazonSocial" class="form-label">Razón Social</label>
                <input type="text" class="form-control" id="inputRazonSocial" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputDocumento" class="form-label">Documento</label>
                <input type="text" class="form-control" id="inputDocumento" placeholder="Número de Dui o Nit" runat="server" />
            </div>
            <div class="col-md-6 mb-3">
                <label for="inputTelefono" class="form-label">Teléfono</label>
                <input type="text" class="form-control" id="inputTelefono" placeholder="0000-0000" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputCorreo" class="form-label">Correo Electrónico</label>
                <input type="email" class="form-control" id="inputCorreo" runat="server" />
            </div>
            <div class="col-md-3 mb-3">
                <label for="ddlDepartamento" class="form-label">Departamento</label>
                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-3 mb-3">
                <label for="inputMunicipio" class="form-label">Municipio</label>
                <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="form-select">
                </asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <label for="inputDireccion" class="form-label">Dirección</label>
                <textarea type="text" class="form-control" id="inputDireccion" runat="server"></textarea>
            </div>
        </div>
        <br />
        <div class="row mb-3">
            <div class="col-md-12">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="inputActivo" runat="server" />
                    <label class="form-check-label" for="inputActivo">
                        Cliente activo
                    </label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>

</asp:Content>
