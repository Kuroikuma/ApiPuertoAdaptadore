using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Dominio.Interfaces.Repositorios
{
	public interface IRepositorioNombre<TEntidad, TEntidadID, TEntidadNombre>
		 : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISeleccionarPorNombre<TEntidad,TEntidadNombre>, ITransaccion
	{ }
}
