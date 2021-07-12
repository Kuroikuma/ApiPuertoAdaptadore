using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Interfaces
{
   
    public interface ISeleccionarPorNombre<TEntidad,TEntidadNombre>
    {
        TEntidad SeleccionarPorNombre(string entidad);
    }
}
