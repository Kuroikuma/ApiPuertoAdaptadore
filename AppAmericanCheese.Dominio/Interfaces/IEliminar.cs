using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Interfaces
{
	public interface IEliminar<TEntidadID>
	{
		void Eliminar(TEntidadID entidadId);
	}
}
