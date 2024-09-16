using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Collections;
using System.ComponentModel;
namespace TPFinalNivel3_MoraCasillas
{
    public partial class FormularioArticulosAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TextId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {

                    MarcaNegocio negocio = new MarcaNegocio();
                    List<Marca> listaMarca = negocio.listar();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> lista = categoriaNegocio.listar();


                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();



                    ddlCategoria.DataSource = lista; // mandamos a llamar nuestros datos
                    ddlCategoria.DataValueField = "id"; // pediremos el id para mostrar la descripción
                    ddlCategoria.DataTextField = "Descripcion"; // Propiedad para obtener ese texto
                    ddlCategoria.DataBind();


                }


                //configuracón si estamos modificando
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int id) && !IsPostBack)
                {

                    ArticuloNegocio negocios = new ArticuloNegocio();
                    List<Articulos> lista = negocios.ModificarAriculo(id);

                    if (lista.Count > 0)
                    {
                        Articulos seleccionado = lista[0];
                        //pre cargar todos los campos...
                        TextId.Text = seleccionado.Id.ToString();
                        txtCodigo.Text = seleccionado.Codigo;
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;

                        ddlMarca.SelectedValue = seleccionado.Marcas.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        txtUrlImagen.Text = seleccionado.ImagenUrl;
                        // Forzaremos el evento de la imagen para que cargue al modificar un disco...
                        txtUrlImagen_TextChanged(sender, e);

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex); // En el caso de haber un error se redirecciona a un pantalla de error
                throw;

            }

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos un objeto 
                //Código de artículo.
                //Nombre.
                //Descripción.
                //Marca(seleccionable de una lista desplegable).
                //Categoría(seleccionable de una lista desplegable.
                //Imagen.
                //Precio.
                // Limpiar cualquier mensaje de error anterior
                lblCodigoError.Visible = false;
                lblNombreError.Visible = false;
                lblDescripcionError.Visible = false;
                lblMarcaError.Visible = false;
                lblCategoriaError.Visible = false;
                lblPrecioError.Visible = false;

                // Crear una lista para almacenar los mensajes de error
                List<string> errores = new List<string>();

                // Validar que los campos obligatorios no estén vacíos
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    lblCodigoError.Text = "El campo Código de artículos no puede estar vacío.";
                    lblCodigoError.Visible = true;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblNombreError.Text = "El campo Nombre no puede estar vacío.";
                    lblNombreError.Visible = true;
                }

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    lblDescripcionError.Text = "El campo Descripción no puede estar vacío.";
                    lblDescripcionError.Visible = true;
                }
                else if (txtDescripcion.Text.Length > 150)
                {
                    lblDescripcionError.Text = "El campo Descripción no puede exceder los 150 caracteres.";
                    lblDescripcionError.Visible = true;
                }

              


                // Validar el campo Precio
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    lblPrecioError.Text = "El campo Precio no puede estar vacío.";
                    lblPrecioError.Visible = true;
                }
                else
                {
                    // Intentar parsear el precio a decimal
                    decimal precio;
                    if (!decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        lblPrecioError.Text = "El campo Precio debe contener solo números.";
                        lblPrecioError.Visible = true;
                    }
                }

                // Si hay errores, salir del método
                if (lblCodigoError.Visible || lblNombreError.Visible || lblDescripcionError.Visible ||
                    lblMarcaError.Visible || lblCategoriaError.Visible || lblPrecioError.Visible)
                {
                    return;
                }


                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();


                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marcas = new dominio.Marca();
                nuevo.Marcas.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new dominio.Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.ImagenUrl = txtUrlImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                // //Creamos una condición para saber si vamos a agregar o modificar un disco...
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(TextId.Text); // con esta línea de código nos aseguramos que se cargue correctamente el id. 
                    //Obtener el id y lo convertimos a entero.
                    negocio.ModificarConSP(nuevo);
                }
                else

                    negocio.agregarSP(nuevo);
                Response.Redirect("Lista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;

            }
        }
        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPreview.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx");

        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }

    }
}