using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
   public class CategoriaNegocio
    {
        public List<Categoria> listar()
		
        {
			List <Categoria> lista= new List<Categoria>();
			AccesoDatos datos = new AccesoDatos();	
			try
			{
				datos.setearconsulta("select id, descripcion from CATEGORIAS ");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Categoria aux = new Categoria();	
					aux.Id = (int)datos.Lector["id"];
					aux.Descripcion = (string)datos.Lector["descripcion"];
					lista.Add(aux);
				}

				return lista;
					
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();	
			}
        }
    }
}
