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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Catalogo.aspx");

        }

        protected void btnIcono_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {

                Usuarios usuarios = new Usuarios();
                UsuariosNegocio negocioNegocio = new UsuariosNegocio();

                EmailService emailService = new EmailService();

                usuarios.Email = txtEmail.Text;
                usuarios.Password = txtPass.Text;
                
                usuarios.id = negocioNegocio.insertarNuevo(usuarios);
                Session.Add("usuarios", usuarios);


                emailService.armarCorreo( usuarios.Email, "¡Bienvenido! Tu perfil fue creado exitosamente.","Te damos la bienvenida");
                emailService.enviaEmail();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
               
                 Response.Redirect("Catalogo.aspx",false);
        }
    }
}