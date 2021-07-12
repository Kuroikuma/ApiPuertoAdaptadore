using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class FacturaDetalle
    {
        public Guid ProductoID { get; set; }
        public Guid FacturaID{ get; set; }
        public decimal CatidadProductosVendido { get; set; }
        public decimal CostoProductosVendido { get; set; }
        public decimal PrecioProductosVendido { get; set; }
        public Factura facturaNav { get; set; }
        public Producto productoNav { get; set; }
    }
}
