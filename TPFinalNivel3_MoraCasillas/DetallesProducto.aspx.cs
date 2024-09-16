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
    public partial class DetallesProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el parámetro "id" de la URL
                string idParam = Request.QueryString["id"];

                // Validar el parámetro "id" y asegurarse de que es un número entero
                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int id))
                {
                    ArticuloNegocio negocios = new ArticuloNegocio();

                    // Obtener la lista de artículos basada en el ID
                    List<Articulos> lista = negocios.listarId(id);

                    // Verificar si la lista contiene elementos
                    if (lista.Count > 0)
                    {
                        Articulos seleccionado = lista[0];

                        // URL de la imagen por defecto si la URL de la base de datos es inválida
                        string defaultImageUrl = "https://queencityonline.com.staging-stable.nmg-platform.com/howards_res/no-image.jpg";

                        // Validar la URL de la imagen
                        string imageUrl = IsValidImageUrl(seleccionado.ImagenUrl) ? seleccionado.ImagenUrl : defaultImageUrl;
                        imgPreview.ImageUrl = imageUrl;

                        // Cargar los datos en los controles de la página
                        lblNombre.Text = seleccionado.Nombre;
                        lblMarca.Text = seleccionado.Marcas.Descripcion;
                        lblPrecio.Text = seleccionado.Precio.ToString("$#,##0.####");
                        lblDescripcion.Text = seleccionado.Descripcion;
                    }
                    else
                    {
                        // Manejar el caso en que no se encontró el artículo
                        lblNombre.Text = "Artículo no encontrado";
                        lblMarca.Text = "";
                        lblPrecio.Text = "";
                        lblDescripcion.Text = "";
                        imgPreview.ImageUrl = "https://queencityonline.com.staging-stable.nmg-platform.com/howards_res/no-image.jpg";
                    }
                }
                else
                {
                    // Manejar el caso en que el parámetro "id" es inválido
                    lblNombre.Text = "ID inválido";
                    lblMarca.Text = "";
                    lblPrecio.Text = "";
                    lblDescripcion.Text = "";
                    imgPreview.ImageUrl = "https://queencityonline.com.staging-stable.nmg-platform.com/howards_res/no-image.jpg";
                }
            }
        }

        private bool IsValidImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            try
            {
                var uri = new Uri(url, UriKind.Absolute);
                if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
                {
                    return false;
                }

                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
                request.Method = "GET"; // Cambiar a GET para manejar redirecciones y obtener el contenido
                request.Timeout = 10000; // Tiempo de espera aumentado a 10 segundos
                request.AllowAutoRedirect = true; // Permitir redirecciones automáticas

                using (var response = (System.Net.HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == System.Net.HttpStatusCode.OK &&
                           response.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (Exception ex)
            {
                // Agrega registros para la depuración
                System.Diagnostics.Debug.WriteLine($"Error al verificar la URL de la imagen: {ex.Message}");
                return false;
            }
        }


        protected void btnIcono_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }
    }
}
