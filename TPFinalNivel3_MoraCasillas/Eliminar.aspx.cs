using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TPFinalNivel3_MoraCasillas
{
    public partial class Eliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Asegúrate de que el ID esté en la URL
            if (!IsPostBack)
            {
                string idStr = Request.QueryString["id"];
                if (string.IsNullOrEmpty(idStr))
                {
                    // Manejar el caso donde no hay ID
                    Response.Redirect("Lista.aspx");
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string idStr = Request.QueryString["id"];
            if (int.TryParse(idStr, out int id))
            {
                // Llama al método eliminar
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(id);

                // Redirige a la lista después de eliminar
                Response.Redirect("Lista.aspx");
            }
            else
            {
                // Manejar el caso donde el ID no es válido
                Response.Redirect("Lista.aspx");
            }
        }
    

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lista.aspx");
        }
    }
}