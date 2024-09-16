<%@ Page Title="" Language="C#" MasterPageFile="~/CatalogoWeb.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/StylePerfil%20-%20Copia.css" rel="stylesheet" />

    <h1>Bienvenido a tu perfil</h1>

    <div class="body">

        <header class="container">
            <label class="content-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese su nombre" CssClass="content-Text" />
            <label class="content-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Ingrese su apellido" CssClass="content-Text" />
            <label class="content-label">Subir Imagen</label>
            <div class="container-input-imagen">
                <input type="file" id="txtImagen" name="txtImagen" class="content-Imagen" runat="server" />
            </div>

            <div class="imagen-preview">
                <asp:Image ID="imgPreview" runat="server" CssClass="imagen-cuadro" ImageUrl="https://thumbs.dreamstime.com/b/sin-foto-ni-icono-de-imagen-en-blanco-cargar-im%C3%A1genes-o-falta-marca-no-disponible-pr%C3%B3xima-se%C3%B1al-silueta-naturaleza-simple-marco-215973362.jpg" />
            </div>

            <div class="content-btn">
                <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-Agregar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CssClass="btn btn-Cancelar" OnClick="btnCancelar_Click" />
            </div>

        </header>
    </div>

</asp:Content>


