using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
	public class CategoriaServicio : IServicioNombre<Categoria, Guid, String>
	{

		private readonly IRepositorioNombre<Categoria, Guid, String> repositorio;

		public CategoriaServicio(IRepositorioNombre<Categoria, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Categoria Agregar(Categoria entidad)
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

		public List<Categoria> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Categoria entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Categoria SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Categoria SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

        public void GuardarTodosLosCambios()
        {
			repositorio.GuardarTodosLosCambios();
		}
    }
}
