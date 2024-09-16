using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_MoraCasillas
{
    public partial class AgruegarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria nuevo = new Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                // Obtener la lista de categorías existentes
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> lista = categoriaNegocio.listar();

                // Verificar si la categoría ya existe
                bool categoriaExiste = lista.Any(c => c.Descripcion.Equals(txtCategoria.Text, StringComparison.OrdinalIgnoreCase));

                if (categoriaExiste)
                {
                    // Si ya existe, mostrar un mensaje o tomar alguna acción
                    lblcategoria.Text = "La categoría ya existe. Por favor, ingrese una nueva categoría.";
                    lblcategoria.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // Si no existe, agregar la nueva categoría
                    nuevo.Descripcion = txtCategoria.Text;
                    negocio.AgregarCategoria(nuevo);

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