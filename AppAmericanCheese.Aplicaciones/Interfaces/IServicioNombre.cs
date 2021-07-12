using AppAmericanCheese.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Interfaces
{
	public interface IServicioNombre<TEntidad, TEntidadID, TEntidadNombre>
		 : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISeleccionarPorNombre<TEntidad, TEntidadNombre>, ITransaccion
	{ }
}				
