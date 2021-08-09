using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Empleado
    {
        public Guid EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int telefono { get; set; }
        public string genero { get; set; }
        public string Correo { get; set; }
        public int tipo { get; set; }
        public string Contraseña { get; set; }
        public List<Factura> facturasNav { get; set;}
    }
}
