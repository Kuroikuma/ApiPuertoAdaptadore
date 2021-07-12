using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Categoria
    {
        public Guid CategoriaID { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }
        public List<Producto> productosNav { get; set; }
    }
}
