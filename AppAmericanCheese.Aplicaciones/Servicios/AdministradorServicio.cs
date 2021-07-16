using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
    public class AdministradorServicio : IServicioNombre<Administrador, Guid, String>
    {

        private readonly IRepositorioNombre<Administrador, Guid, String> repositorio;

        public AdministradorServicio(IRepositorioNombre<Administrador, Guid, String> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Administrador Agregar(Administrador entidad)
        {
            if(entidad != null)
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

        public void Editar(Administrador entidad)
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

        public List<Administrador> Listar()
        {
                return repositorio.Listar();
            }

        public Administrador SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public Administrador SeleccionarPorNombre(string entidad)
        {
            return repositorio.SeleccionarPorNombre(entidad);
        }
    }
}
