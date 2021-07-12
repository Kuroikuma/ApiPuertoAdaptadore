using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
	public class ClienteServicio : IServicioNombre<Cliente, Guid, String>
	{

		private readonly IRepositorioNombre<Cliente, Guid, String> repositorio;

		public ClienteServicio(IRepositorioNombre<Cliente, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Cliente Agregar(Cliente entidad)
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

		public List<Cliente> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Cliente entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Cliente SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Cliente SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

        public void GuardarTodosLosCambios()
        {
			repositorio.GuardarTodosLosCambios();
		}
    }
}
