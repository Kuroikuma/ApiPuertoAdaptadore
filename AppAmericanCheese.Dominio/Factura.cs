using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Factura
    {
        public bool anulado;

        public Guid FacturaID { get; set; }
        public Guid EmpleadoID { get; set; }
        public Guid ClienteID { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public Empleado empleadoNav { get; set; }
        public Cliente clienteNav { get; set; }
        public List<FacturaDetalle> facturaDetallesNav { get; set; }

    }
}
