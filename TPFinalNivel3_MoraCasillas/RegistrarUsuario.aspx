<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.RegistrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/StyleRegistrar.css" rel="stylesheet" />
      <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

    <title>RegistroUsuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="main-containerLogo">
                <div class="logo-container">
                    <itemtemplate>
                        <asp:LinkButton ID="btnIcono" runat="server" CssClass="btn-link" BorderStyle="None" Style="color: #3483fa" onclick="btnIcono_Click">
                            <i class="fa-solid fa-store logo-icon"></i>
                            <asp:Label Text="GigaShop" runat="server" ID="logoLabel" CssClass="LogoLetra" BorderStyle="None" />
                        </asp:LinkButton>
                    </itemtemplate>
                </div>
            </div>
        </div>


        <h1>Crea tu cuenta</h1>
        <header class="main-container">
            <label class="content-label">Ingresa un email</label>
            <asp:TextBox id="txtEmail" runat="server" TextMode="Email" placeholder="ejemplo@ejemplo.com" CssClass="content-email-pass" />
            <label class="content-label">Crea una contraseña</label>
            <asp:TextBox id="txtPass" runat="server" TextMode="Password" CssClass="content-email-pass" />
            <div class="content-btn">
                <asp:Button ID="btnContinuar" Text="Continuar" runat="server" CssClass="btn btn-Continuar" onclick="btnContinuar_Click" />
                <asp:Button ID="btnRegresar" Text="Cancelar" runat="server" CssClass="btn btn-Regresar" onclick="btnRegresar_Click" /> 
            </div>
        </header>

    </form>
</body>
</html>
