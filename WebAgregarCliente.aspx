<%@ Page Title="Agregar Cliente" Language="vb" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="WebAgregarCliente.aspx.vb" Inherits="GestionClientes.WebAgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Agregar Cliente</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 id="lblTitulo" runat="server" class="mb-4">Adición de Cliente</h3>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputNombreComercial" class="form-label">Nombre Comercial</label>
                <input type="text" class="form-control" id="inputNombreComercial" runat="server" maxlength="150" />
                <asp:RequiredFieldValidator
                    ID="rfvNombreComercial"
                    runat="server"
                    ControlToValidate="inputNombreComercial"
                    ErrorMessage="El nombre comercial es requerido."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label for="inputRazonSocial" class="form-label">Razón Social</label>
                <input type="text" class="form-control" id="inputRazonSocial" runat="server" maxlength="150" />
                <asp:RequiredFieldValidator
                    ID="rfvRazonSocial"
                    runat="server"
                    ControlToValidate="inputRazonSocial"
                    ErrorMessage="La razón social es requerida."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputDocumento" class="form-label">Documento</label>
                <input type="text" class="form-control" id="inputDocumento" placeholder="Número de Dui o Nit" runat="server" maxlength="10" />
                <asp:RegularExpressionValidator
                    ID="revDUI"
                    runat="server"
                    ControlToValidate="inputDocumento"
                    ValidationExpression="^\d{8}-\d{1}$"
                    ErrorMessage="Formato de DUI inválido. Ej: 12345678-9"
                    CssClass="text-danger"
                    Display="Dynamic" />
                <asp:RequiredFieldValidator
                    ID="rfvDocumento"
                    runat="server"
                    ControlToValidate="inputDocumento"
                    ErrorMessage="El numero de documento es requerido."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label for="inputTelefono" class="form-label">Teléfono</label>
                <input type="text" class="form-control" id="inputTelefono" placeholder="0000-0000" runat="server" maxlength="9" />
                <asp:RegularExpressionValidator
                    ID="revTelefono"
                    runat="server"
                    ControlToValidate="inputTelefono"
                    ValidationExpression="^\d{4}-\d{4}$"
                    ErrorMessage="Formato de teléfono inválido. Ej: 1234-5678"
                    CssClass="text-danger"
                    Display="Dynamic" />
                <asp:RequiredFieldValidator
                    ID="rfvTelefono"
                    runat="server"
                    ControlToValidate="inputTelefono"
                    ErrorMessage="El numero de teléfono es requerido."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="inputCorreo" class="form-label">Correo Electrónico</label>
                <input type="email" class="form-control" id="inputCorreo" runat="server" maxlength="150" />
                <asp:RegularExpressionValidator
                    ID="revCorreo"
                    runat="server"
                    ControlToValidate="inputCorreo"
                    ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,4}$"
                    ErrorMessage="Correo inválido."
                    CssClass="text-danger"
                    Display="Dynamic" />
                <asp:RequiredFieldValidator
                    ID="rfvCorreo"
                    runat="server"
                    ControlToValidate="inputCorreo"
                    ErrorMessage="El correo es requerido."
                    CssClass="text-danger"
                    Display="Dynamic" />

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
                <asp:RequiredFieldValidator
                    ID="rfvDireccion"
                    runat="server"
                    ControlToValidate="inputDireccion"
                    ErrorMessage="La dirección es requerida."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Agregar Cliente" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
