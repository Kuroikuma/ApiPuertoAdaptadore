using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAmericanCheese.Dominio.Interfaces;

namespace AppAmericanCheese.Aplicaciones.Interfaces
{
	public interface IServicioBase<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
	{ }
}
