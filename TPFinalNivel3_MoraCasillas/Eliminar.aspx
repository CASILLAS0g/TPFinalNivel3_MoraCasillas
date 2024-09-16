<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.Eliminar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eliminar</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <link href="Styles/EstilosEliminar.css" rel="stylesheet" />
       <div id="custom-confirm" class="custom-confirm" >
            <div class="custom-confirm-content">
                <p>¿Estás seguro de que deseas eliminar este artículo?</p>
                 <asp:Button Text="Sí" runat="server" ID="btnConfirmar" CssClass="btn-confirmar" OnClick="btnConfirmar_Click" />
                <asp:Button Text="No" runat="server" ID="btnCancelar" CssClass="btn-cancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
