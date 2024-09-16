<%@ Page Title="" Language="C#" MasterPageFile="~/CatalogoWeb.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="TPFinalNivel3_MoraCasillas.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/EstilosListaGrid%20-%20Copia%20-%20Copia.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css" rel="stylesheet">
    <div class="container mt-5">
        <h1 style="padding-left: 10px;">Lista Artículos</h1>




        <div class="form-group filter-container">
            <asp:Label Text="Campo" ID="lblCampo" runat="server" />

            <div class="input-group">
                <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddlCampoFiltro" OnSelectedIndexChanged="ddlCampoFiltro_SelectedIndexChanged">
                    <asp:ListItem Text="Precio" Value="Precio" />
                    <asp:ListItem Text="Marca" Value="Marca" />
                    <asp:ListItem Text="Categoria" Value="Categoria" />
                </asp:DropDownList>
            </div>

            <label for="ddlCriterio">Criterio</label>
            <div class="input-group">
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <label for="txtFiltro">Filtro</label>
            <div class="input-group">
                <asp:Label Text="" ID="lblError" runat="server" style="color:red"/>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
            </div>

            <div class="input-group">
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn-Marca" OnClick="btnBuscar_Click" />
            </div>
            <div class="input-group">
                <asp:Button Text="Limpiar filtro" runat="server" ID="btnLimpiarFiltro" CssClass="btn-Marca" onclick="btnLimpiarFiltro_Click" />
            </div>
        </div>


        <div class="table-container">
            <asp:GridView ID="dgvArticulos" runat="server" CssClass="custom-table table-hover"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="8" DataKeyNames="Id"
                OnRowCommand="dgvArticulos_RowCommand" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowDataBound="dgvArticulos_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Título" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marcas.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Modificar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit"
                                CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-link">
                        <i class="bi bi-pen-fill"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar"
                                CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-eliminar">
                        <i class="bi bi-trash"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="button-container">
            <a href="FormularioArticulosAgregar.aspx" class="btn btn-Agregar">Agregar</a>

            <div class="secondary-buttons">
                <asp:Button ID="btnAgregarMarca" OnClick="btnAgregarMarca_Click" runat="server" Text="Agregar Marca" CssClass="btn btn-Marca" />
                <asp:Button ID="btnAgregarCategoria" OnClick="btnAgregarCategoria_Click" runat="server" Text="Agregar Categoría" CssClass="btn btn-Categoria" />
            </div>
        </div>
    </div>


</asp:Content>
