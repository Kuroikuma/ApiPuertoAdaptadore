using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Cliente
    {
        public Guid ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int tipo { get; set; }
        public string usuario { get; set; }
        public string Contraseña { get; set; }
        public List<Factura> facturasNav { get; set; }
    }
}
