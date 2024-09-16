using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
		public List<Marca> listar()
		{
			List<Marca> lista = new List<Marca>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearconsulta("select id, Descripcion from MARCAS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Marca aux = new Marca();
					aux.Id = (int)datos.Lector["id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

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
