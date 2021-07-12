using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class CrearProducto
    {
        public Guid CrearProductoID { get; set; }
        public Guid ProductoID { get; set; }
        public Guid IngredienteID { get; set; }
        public decimal CantidadIngrediente { get; set; }
        public decimal CostoDeIngredientes { get; set; }
        public Producto productoNav { get; set; }
        public Ingrediente ingredienteNav { get; set; }

    }
}
