using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Entidades
{
    public class Ingrediente
    {
        public Guid IngredienteID { get; set; }
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }
<<<<<<< HEAD
        public string unidadMedida { get; set; }
=======
        public decimal onzas { get; set; }
>>>>>>> f00787f50d8596c313b15025e195c738be11fa40
        public List<CrearProducto> crearProductosNav { get; set; }
    }
}
