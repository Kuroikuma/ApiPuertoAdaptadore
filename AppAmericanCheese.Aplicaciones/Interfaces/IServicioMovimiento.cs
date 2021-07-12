using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppAmericanCheese.Dominio.Interfaces;

namespace AppAmericanCheese.Aplicaciones.Interfaces
{
	public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
	{
		void Anular(TEntidadID entidadId);
	}
}
