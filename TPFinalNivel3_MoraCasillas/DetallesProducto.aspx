<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesProducto.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.DetallesProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/StyleDetallesProducto%20-%20-%20Copia.css" rel="stylesheet" />
    <title>Detalles</title>
</head>
<body>
    <form id="form1" runat="server">


        <div class="header">
            <div class="main-containerLogo">
                <div class="logo-container">
                    <itemtemplate>
                        <asp:LinkButton ID="btnIcono" runat="server" CssClass="btn-link" BorderStyle="None" Style="color: #3483fa" OnClick="btnIcono_Click">
                            <i class="fa-solid fa-store logo-icon"></i>
                            <asp:Label Text="GigaShop" runat="server" ID="logoLabel" CssClass="LogoLetra" BorderStyle="None"  />
                        </asp:LinkButton>
                    </itemtemplate>
                </div>
            </div>
        </div>


        <div class="product-details-container">
            <div class="product-image">
                <asp:Image ID="imgPreview" runat="server" CssClass="imagen-cuadro"
                     />
            </div>
            <div class="product-info">
                <div>
                <asp:Label Text="" runat="server" CssClass="product-name" ID="lblNombre" />
                </div>
                <div>
                <asp:Label Text="" runat="server" CssClass="product-brand" ID="lblMarca" />

                </div>
                <div> 
                <asp:Label Text="" runat="server" CssClass="product-brand" ID="lblPrecio" />

                </div>
                <div>
                    <div>

                    Descripción:
                    </div>
                <asp:Label Text="" runat="server" CssClass="product-brand" ID="lblDescripcion" />
                </div>

            </div>
            <div class="button-container">
                <a href="Catalogo.aspx" class="btn-regresar">Regresar</a>
            </div>
        </div>
    </form>
</body>
</html>
