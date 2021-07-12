using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
	public class EmpleadoServicio : IServicioNombre<Empleado, Guid, String>
	{

		private readonly IRepositorioNombre<Empleado, Guid, String> repositorio;

		public EmpleadoServicio(IRepositorioNombre<Empleado, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Empleado Agregar(Empleado entidad)
		{
			if (entidad != null)
			{
				var resultado = repositorio.Agregar(entidad);
				repositorio.GuardarTodosLosCambios();
				return resultado;
			}
			else
				throw new Exception("Error la entidad no puede ser nula");
		}

		public List<Empleado> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Empleado entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Empleado SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Empleado SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

        public void GuardarTodosLosCambios()
        {
			repositorio.GuardarTodosLosCambios();
		}
    }
}
