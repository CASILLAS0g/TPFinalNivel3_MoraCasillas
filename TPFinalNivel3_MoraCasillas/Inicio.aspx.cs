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
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIcono_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", true);
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Usuarios usuarios = new Usuarios();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                usuarios.Email = txtEmail.Text;
                usuarios.Password = txtPass.Text;
                

                if (negocio.Login(usuarios))
                {
                    Session.Add("usuarios", usuarios);
                    Response.Redirect("Catalogo.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o Password incorrectos");
                    Response.Redirect("Error.aspx",false);
                }
            }
           
            catch (Exception ex)
            {
                
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUsuario.aspx", true);
        }

    }
}