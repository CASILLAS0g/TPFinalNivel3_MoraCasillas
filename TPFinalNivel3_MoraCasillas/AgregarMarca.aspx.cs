using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPFinalNivel3_MoraCasillas
{
    public partial class AgruegarMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Restaurar los valores de ViewState si existen
                if (ViewState["Marca"] != null)
                {
                    txtMarca.Text = ViewState["Marca"].ToString();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca nuevo = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                // Obtener la lista de Marca existentes
                MarcaNegocio MarcaNegocio = new MarcaNegocio();
                List<Marca> lista = MarcaNegocio.listar();

                // Verificar si la Marca ya existe
                bool categoriaExiste = lista.Any(c => c.Descripcion.Equals(txtMarca.Text, StringComparison.OrdinalIgnoreCase));

                if (categoriaExiste)
                {
                    // Si ya existe, mostrar un mensaje o tomar alguna acción
                    lblMarca.Text = "La categoría ya existe. Por favor, ingrese una nueva categoría.";
                    lblMarca.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // Si no existe, agregar la nueva categoría
                    nuevo.Descripcion = txtMarca.Text;
                    negocio.AgregarMarca(nuevo);

                    // Guardar el valor en ViewState
                    ViewState["Marca"] = txtMarca.Text;

                    Response.Redirect("Lista.aspx");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Session.Add("Error", ex);
                throw;
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lista.aspx");
        }

    }
}