<%@ Page Title="" Language="C#" MasterPageFile="~/CatalogoWeb.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Styles/EstilosCatalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="tarjeta-container">
        <asp:Repeater ID="reRepetidor" runat="server">
            <ItemTemplate>
                <div class="card">
                    <div class="card-imagen">
                        <asp:Image ID="imgPreview" runat="server" CssClass="card-image" ImageUrl='<%# GetImageUrl(Eval("ImagenUrl")) %>' />

                    </div>
                    <div class="card-content">
                        <h3 class="card-title"><%# Eval("Nombre") %></h3>

                        <p class="card-description"><%# Convert.ToDecimal(Eval("Precio")).ToString("$#,##0.####") %></p>
                    </div>
                    <div class="card-footer">

                        <asp:Button Text="Ver" CssClass="card-button" runat="server" ID="btnDetalles" CommandArgument='<%# Eval("Id") %>'
                            CommandName="ArticuloID" OnClick="btnDetalles_Click1" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>



