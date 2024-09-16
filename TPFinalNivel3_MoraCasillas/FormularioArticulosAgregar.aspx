<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioArticulosAgregar.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.FormularioArticulosAgregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/EstilosFormularioArticulos%20-%20Copia%20-%20Copia%20-%20Copia.css" rel="stylesheet" />
    <title>Agregar</title>
</head>
<body>


    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" />

        <div class="form-container">
            <h2>Registrar Artículos</h2>
            <div class="form-group">
                <label for="txtId">Id</label>
                <asp:TextBox ID="TextId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCodigo">Código de artículos:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblCodigoError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblNombreError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtDescripcion">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblDescripcionError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
                <label for="ddlMarca">Marca:</label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblMarcaError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
                <label for="ddlCategoria">Categoría:</label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblCategoriaError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtPrecio">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblPrecioError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label for="txtUrlImagen">URL de la Imagen:</label>
                        <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group imagen-preview">
                        <asp:Image ID="imgPreview" runat="server" CssClass="imagen-cuadro" ImageUrl="https://queencityonline.com.staging-stable.nmg-platform.com/howards_res/no-image.jpg" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="form-buttons">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <a href="Lista.aspx" class="btn btn-secondary" id="btnCancelar">Cancelar</a>
            </div>

        </div>


    </form>
</body>
</html>
