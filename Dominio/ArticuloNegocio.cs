using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio; 

namespace negocio
{
    public  class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Articulos> listar()
        {
            List<Articulos> listar = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "Server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true; ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.id, codigo, nombre , A.Descripcion,  IdMarca, M.Descripcion AS Marcas ,IdCategoria, C.Descripcion AS Categorias, ImagenUrl, Precio  from ARTICULOS A \r\ninner join MARCAS M\r\non A.IdMarca = M.ID\r\nINNER JOIN CATEGORIAS C\r\nON A.IdCategoria = C.ID";
                comando.Connection = conexion; 
               
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)lector["id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marcas = new Marca();
                    aux.Marcas.Id = (int)lector["IdMarca"];
                    aux.Marcas.Descripcion = (string)lector["Marcas"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"]
                ;
                    aux.Categoria.Descripcion= (string)lector["Categorias"];
                    if (!(lector["ImagenUrl"] is DBNull))
                    aux.ImagenUrl = (string)lector["ImagenUrl"];


                    aux.Precio = (decimal)lector["Precio"];


                    listar.Add(aux);  
                }

                conexion.Close();
                return listar;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearconsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,idMarca,idCategoria,ImagenUrl,Precio) values (@Codigo,@Nombre,@Descripcion,@idMarcas,@idCategorias,@ImagenUrl,@Precio) ");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarcas", nuevo.Marcas.Id);
                datos.setearParametro("@idCategorias",nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();

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

        public void modificar(Articulos modificar)
        {
            
            try
            {
                datos.setearconsulta("update ARTICULOS set Codigo = @Codigo , Nombre= @Nombre, Descripcion= @Descripcion , IdMarca = @IdMarca, IdCategoria = @IdCategoria , ImagenUrl= @ImagenUrl, Precio = @Precio");
                datos.setearParametro("@Codigo",modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro(" @Descripcion ", modificar.Descripcion);
                datos.setearParametro(" @IdMarca", modificar.Marcas.Id);
                datos.setearParametro(" @IdCategoria", modificar.Categoria.Id);
                datos.setearParametro(" @ImagenUrl", modificar.ImagenUrl);
                datos.setearParametro(" @Precio", modificar.Precio);
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }

     
    
        

        public void eliminar (int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearconsulta ("delete ARTICULOS where id = @Id");
            datos.setearParametro("@Id",id);
            datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex; 
            }



        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List <Articulos> listar = new List <Articulos>();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                string consulta = ("select A.id, codigo, nombre , A.Descripcion,  IdMarca, M.Descripcion AS Marcas ,IdCategoria, C.Descripcion AS Categorias, ImagenUrl, Precio  from ARTICULOS A \r\ninner join MARCAS M\r\non A.IdMarca = M.ID\r\nINNER JOIN CATEGORIAS C\r\nON A.IdCategoria = C.ID ");

               
                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "where codigo like '" + filtro + "%' "; 
                            break;
                        case "Termina con":
                            consulta += "where codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "where codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where Nombre like '" + filtro + " %' ";
                            break;
                        case "Termina con":
                            consulta += " where Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "where A.Descripcion like '" + filtro + " %' ";
                            break;
                        case "Termina con":
                            consulta += "where A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "where A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearconsulta(consulta);
                datos.ejecutarLectura();
              

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marcas = new Marca();
                    aux.Marcas.Id = (int)datos.Lector["IdMarca"];
                    aux.Marcas.Descripcion = (string)datos.Lector["Marcas"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"]
                ;
                    aux.Categoria.Descripcion = (string)datos.Lector["Categorias"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    aux.Precio = (decimal)datos.Lector["Precio"];


                    listar.Add(aux);
                }
                return listar; 
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
    }
