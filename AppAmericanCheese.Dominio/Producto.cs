using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Producto
    {
        public Guid ProductoID { get; set; }
        public Guid CategoriaID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Tamaño { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }
        public Boolean isStock { get; set; }
        public string Descripcion { get; set; }
        public Categoria categoriaNav { get; set; }
        public List<CrearProducto> crearProductosNav { get; set; }
        public List<FacturaDetalle> facturaDetalleNav { get; set; }
       
    }
}
