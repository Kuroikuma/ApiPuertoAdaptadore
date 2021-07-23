using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
    public class RootServicio : IServicioNombre<Root, Guid, String>
    {

        private readonly IRepositorioNombre<Root, Guid, String> repositorio;

        public RootServicio(IRepositorioNombre<Root, Guid, String> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Root Agregar(Root entidad)
        {
            if (entidad != null)
            {
                var resultado = repositorio.Agregar(entidad);
                repositorio.GuardarTodosLosCambios();
                return resultado;
            }
            else
            {
                throw new Exception("La entidad no puede ser nula");
            }
        }

        public void Editar(Root entidad)
        {
            repositorio.Editar(entidad);
            repositorio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repositorio.Eliminar(entidadId);
            repositorio.GuardarTodosLosCambios();
        }

        public void GuardarTodosLosCambios()
        {
            repositorio.GuardarTodosLosCambios();
        }

        public List<Root> Listar()
        {
            return repositorio.Listar();
        }

        public Root SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public Root SeleccionarPorNombre(string entidad)
        {
            return repositorio.SeleccionarPorNombre(entidad);
        }
    }
}
