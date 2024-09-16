﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio 
{
    public class Articulos
    {
        //id,Codigo, Nombre, Descripcion, IdMarca, IdCategoria , ImagenUrl, Precio 
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }

        public string Nombre { get; set; }
            
        [DisplayName("Descipción")]
        public string Descripcion { get; set; }
        public Marca Marcas { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        
        public string ImagenUrl { get; set; }
        public Decimal Precio { get; set; }
       
    }
}
