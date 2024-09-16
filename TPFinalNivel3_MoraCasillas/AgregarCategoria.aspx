<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.AgruegarCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Categoria</title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="Styles/EstilosMarcaCategoria.css" rel="stylesheet" />
        <div id="custom-confirm" class="custom-confirm">
            <div class="custom-confirm-content">
                <asp:Label ID="lblcategoria" runat="server" Text="Agregue una categoría"></asp:Label>
                <asp:TextBox runat="server" id ="txtCategoria" placeholder="@Audio" CssClass="textBox"/>
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn-confirmar" OnClick="btnAgregar_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn-cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
