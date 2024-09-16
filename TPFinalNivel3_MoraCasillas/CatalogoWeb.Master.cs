using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3_MoraCasillas
{
    public partial class CatalogoWeb : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            if (!(Page is Perfil || Page is Formulario_web1 || Page is Error || Page is Formulario_web11))
            {
                if (!Seguridad.sesionActiva(Session["usuarios"]))
                    Response.Redirect("Inicio.aspx", false);
            }

            if (Seguridad.sesionActiva(Session["usuarios"]))
            {
                Usuarios usuario = (Usuarios)Session["usuarios"];
                string imagenUrl = "~/imagenes/" + usuario.ImagenPerfil;
                string rutaImagen = Server.MapPath(imagenUrl);

                if (File.Exists(rutaImagen) && !string.IsNullOrEmpty(usuario.ImagenPerfil))
                {
                    imagenPerfilMaster.ImageUrl = imagenUrl + "?t=" + DateTime.Now.Ticks; // Evita caching
                }
                else
                {
                    imagenPerfilMaster.ImageUrl = "https://saberescincopuntocero.com/wp-content/uploads/2020/10/PERFIL-VACIO-300x300.png";
                }
            }
            else
            {
                imagenPerfilMaster.ImageUrl = "https://saberescincopuntocero.com/wp-content/uploads/2020/10/PERFIL-VACIO-300x300.png";
            }

                // Opcional: Puedes cargar alguna información inicial aquí
            }
        }




        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim(); // Obtener el término de búsqueda

            // Redirigir a la misma página con el término de búsqueda como parámetro
            string currentPage = Request.Url.AbsolutePath; // Obtener la página actual
            Response.Redirect(currentPage + "?search=" + Server.UrlEncode(searchTerm));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }
      
        
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx");
        }
    }

}
