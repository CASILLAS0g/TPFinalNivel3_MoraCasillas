using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Diagnostics;
using System.IO;
namespace TPFinalNivel3_MoraCasillas
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.sesionActiva(Session["usuarios"]))
                {
                    Response.Redirect("Inicio.aspx", false);
                }

                Usuarios usuario = (Usuarios)Session["usuarios"];

                if (usuario != null)
                {
                    // Verificar si la propiedad ImagenPerfil es nula o vacía
                    if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    {
                        // Asignar la URL de la imagen con parámetro para evitar caché
                        imgPreview.ImageUrl = "~/imagenes/" + usuario.ImagenPerfil + "?t=" + DateTime.Now.Ticks;
                    }
                    else
                    {
                        // Si no hay imagen, asignar una imagen predeterminada
                        imgPreview.ImageUrl = "https://saberescincopuntocero.com/wp-content/uploads/2020/10/PERFIL-VACIO-300x300.png";
                    }

                    // Cargar nombre y apellido
                    txtNombre.Text = usuario.Nombre ?? "";
                    txtApellido.Text = usuario.Apellido ?? "";
                }
            }
        }


        // Ejemplo de depuración adicional
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuariosNegocio negocio = new UsuariosNegocio();
                Usuarios usuarios = (Usuarios)Session["usuarios"];

                // Verificar datos antes de la actualización
                Debug.WriteLine("Nombre: " + txtNombre.Text);
                Debug.WriteLine("Apellido: " + txtApellido.Text);

                // Guardar la imagen si se cargó algo
                if (txtImagen.PostedFile != null && !string.IsNullOrEmpty(txtImagen.PostedFile.FileName))
                {
                    string ruta = Server.MapPath("~/imagenes/");
                    string imagenNombre = "perfil-" + usuarios.id + ".jpg";
                    string rutaImagenCompleta = Path.Combine(ruta, imagenNombre);

                    txtImagen.PostedFile.SaveAs(rutaImagenCompleta);
                    usuarios.ImagenPerfil = imagenNombre;
                }

                // Guardar el nombre y apellido en el objeto usuario
                usuarios.Nombre = txtNombre.Text.Trim();
                usuarios.Apellido = txtApellido.Text.Trim();

                // Actualizar en la base de datos
                negocio.Actualizar(usuarios);

                // Actualizar la sesión con los nuevos datos
                Session["usuarios"] = usuarios;

                // Actualizar la imagen en la master page si es necesario
                Image img = (Image)Master.FindControl("imagenPerfilMaster");
                if (img != null)
                {
                    img.ImageUrl = "~/imagenes/" + usuarios.ImagenPerfil + "?t=" + DateTime.Now.Ticks; // Evita caching
                }

                // Redirigir a la página de perfil
                Response.Redirect("Catalogo.aspx");
            }
            catch (Exception ex)
            {
                // Manejar el error y mostrarlo en la sesión para depuración
                Session["error"] = ex.ToString();
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }
    }
}