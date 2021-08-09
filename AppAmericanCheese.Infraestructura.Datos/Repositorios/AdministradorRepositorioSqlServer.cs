using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
    public class AdministradorRepositorioSqlServer : IRepositorioNombre<Administrador, Guid, String>
    {

        private DbAmericanCheese db;

        public AdministradorRepositorioSqlServer(DbAmericanCheese _db)
        {
            db = _db;
        }

        public Administrador Agregar(Administrador entidad)
        {
            entidad.AdministradoID = Guid.NewGuid();

            db.Administrador.Add(entidad);

            return entidad;
        }

        public void Editar(Administrador entidad)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidad.AdministradoID).FirstOrDefault();
            if (AdministradorSeleccionado != null)
            {
                AdministradorSeleccionado.Nombre = entidad.Nombre;
                AdministradorSeleccionado.Apellido = entidad.Apellido;
                AdministradorSeleccionado.Contraseña = entidad.Contraseña;

                db.Entry(AdministradorSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidadId).FirstOrDefault();
            if (AdministradorSeleccionado != null)
            {
                db.Administrador.Remove(AdministradorSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Administrador> Listar()
        {
            return db.Administrador.ToList();
        }

        public Administrador SeleccionarPorID(Guid entidadId)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidadId).FirstOrDefault();
            return AdministradorSeleccionado;
        }

        public Administrador SeleccionarPorNombre(string entidad)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.Nombre == entidad).FirstOrDefault();
            return AdministradorSeleccionado;
        }
    }
}
