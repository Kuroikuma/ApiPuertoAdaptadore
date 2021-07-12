using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Interfaces
{
    public interface ISeleccionar_DetallePorMovimento <TEntidad, TMovimientoID>
    {
        List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);
    }
}
