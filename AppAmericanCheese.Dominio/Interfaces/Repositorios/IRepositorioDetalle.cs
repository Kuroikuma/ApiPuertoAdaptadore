using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Interfaces.Repositorios
{
	public interface IRepositorioDetalle<TEntidad, TMovimientoID>
		: IAgregar<TEntidad>, ITransaccion
	{

		List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);
	}
}
