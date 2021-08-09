using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio
{
    public class Root
    {
        public Guid RootID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int telefono { get; set; }
        public string Imagen { get; set; }
        public string genero { get; set; }
        public string Correo { get; set; }
        public int tipo { get; set; }
        public string Contraseña { get; set; }
    }
}
