using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_MoraCasillas
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los artículos inicialmente, puede incluir lógica para búsquedas basadas en URL
                ArticuloNegocio negocio = new ArticuloNegocio();

                string searchTerm = Request.QueryString["search"];
                ListaArticulos = string.IsNullOrEmpty(searchTerm)
                    ? negocio.listarConSP()
                    : negocio.listarConSP().Where(a => a.Nombre.ToLower().Contains(searchTerm.ToLower())).ToList();

                reRepetidor.DataSource = ListaArticulos;
                reRepetidor.DataBind();

                
               
            }
           
        }

        protected void btnDetalles_Click1(object sender, EventArgs e)
        {
            //Ceamos un objeto para obtener los métodos del sender 
            Button btn = (Button)sender;

            //creamos un objeto para asignar el command
            string productoId = btn.CommandArgument;

            string url = "DetallesProducto.aspx?id=" + productoId;

            Response.Redirect(url);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        // Método para obtener la URL de la imagen correcta
        public string GetImageUrl(object imagenUrl)
        {
            // URL de la imagen por defecto
            string defaultImageUrl = "https://queencityonline.com.staging-stable.nmg-platform.com/howards_res/no-image.jpg";

            if (imagenUrl != null)
            {
                string url = imagenUrl.ToString();
                // Verificar si la URL es válida
                if (!string.IsNullOrWhiteSpace(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute) && (url.StartsWith("http://") || url.StartsWith("https://")))
                {
                    return url;
                }
            }

            return defaultImageUrl;
        }
    }

} 