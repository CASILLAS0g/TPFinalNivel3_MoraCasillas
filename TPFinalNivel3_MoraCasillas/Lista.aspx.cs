using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TPFinalNivel3_MoraCasillas
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["usuarios"]))
            {
                Session.Add("error", "Se necesitan permisos de admin para navegar en esta pantalla");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack) // Asegúrate de que los artículos se carguen solo en el primer acceso
            {
                CargarArticulos();
            }



        }


        private void CargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string searchTerm = Request.QueryString["search"];

            var articulos = string.IsNullOrEmpty(searchTerm)
                ? negocio.listarConSP()
                : negocio.listarConSP().Where(a => a.Nombre.ToLower().Contains(searchTerm.ToLower())).ToList(); // Aquí se corrige

            dgvArticulos.DataSource = articulos;
            dgvArticulos.DataBind();
        }

        // ... (resto del código permanece igual)



        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulosAgregar.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            CargarArticulos(); // Re-carga los artículos
        }

        protected void dgvArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal precio = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Precio"));
                Label lblPrecio = (Label)e.Row.FindControl("lblPrecio");

                // Formato para mostrar comas y hasta cuatro decimales sin redondear
                lblPrecio.Text = precio.ToString("$#,##0.####");
            }
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Obtiene el ID del artículo seleccionado
                string commandArgument = e.CommandArgument.ToString();
                int id;

                // Verifica si el CommandArgument es un número válido
                if (int.TryParse(commandArgument, out id))
                {
                    Response.Redirect("FormularioArticulosAgregar.aspx?id=" + id);
                }
            }
            if (e.CommandName == "Eliminar")
            {
                // Obtiene el ID del artículo seleccionado
                string commandArgument = e.CommandArgument.ToString();
                int id;

                // Verifica si el CommandArgument es un número válido
                if (int.TryParse(commandArgument, out id))
                {
                    Response.Redirect("Eliminar.aspx?id=" + id);
                }
            }

        }



        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx");
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }



        protected void ddlCampoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedField = ddlCampoFiltro.SelectedValue;

            // Limpiar los criterios existentes
            ddlCriterio.Items.Clear();

            // Agregar criterios según el campo seleccionado
            if (selectedField == "Precio")
            {
                ddlCriterio.Items.Add(new ListItem("Mayor a", "Mayor a"));
                ddlCriterio.Items.Add(new ListItem("Menor a", "Menor a"));
                ddlCriterio.Items.Add(new ListItem("Igual a", "Igual a"));
            }
            else if (selectedField == "Marca" || selectedField == "Categoria")
            {
                ddlCriterio.Items.Add(new ListItem("Comienza con", "Comienza con"));
                ddlCriterio.Items.Add(new ListItem("Termina con", "Termina con"));
                ddlCriterio.Items.Add(new ListItem("Contiene", "Contiene"));
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = ddlCampoFiltro.SelectedValue;
            string criterio = ddlCriterio.SelectedValue;
            string filtro = txtFiltro.Text.Trim();


            if (campo == "Precio")
            {
                // Validar si el filtro es un número
                if (!decimal.TryParse(filtro, out _))
                {
                    // Mostrar mensaje de error si no es un número
                    lblError.Text = "Solo números.";
                    lblError.Visible = true;
                    return;
                }
            }
            lblError.Visible = false;

            // Validar que el campo, criterio y filtro no estén vacíos
            if (string.IsNullOrEmpty(campo) || string.IsNullOrEmpty(criterio) || string.IsNullOrEmpty(filtro))
            {
                // Manejar el error: Mostrar mensaje o similar
                return;
            }

            // Obtener los resultados del filtrado
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulos> resultados = negocio.filtrar(campo, criterio, filtro);

            // Enlazar los resultados al GridView
            dgvArticulos.DataSource = resultados;
            dgvArticulos.DataBind();
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lista.aspx");
            
        }
    }
}
