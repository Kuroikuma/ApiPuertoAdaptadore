using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class ClienteRepositorioSqlServer : IRepositorioNombre<Cliente, Guid, String>
	{

		private DbAmericanCheese db;

		public ClienteRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

		public Cliente Agregar(Cliente Cliente)
		{
			Cliente.ClienteID = Guid.NewGuid();

			db.Clientes.Add(Cliente);

			return Cliente;
		}

		public List<Cliente> Listar()
		{
			return db.Clientes.ToList();
		}

		public void Editar(Cliente Cliente)
		{
			var ClienteSeleccionado = db.Clientes.Where(c => c.ClienteID == Cliente.ClienteID).FirstOrDefault();
			if (ClienteSeleccionado != null)
			{
				ClienteSeleccionado.Nombre = Cliente.Nombre;
				ClienteSeleccionado.Contraseña = Cliente.Contraseña;
				ClienteSeleccionado.Correo = Cliente.Correo;
				db.Entry(ClienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var ClienteSeleccionado = db.Clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
			if (ClienteSeleccionado != null)
			{
				db.Clientes.Remove(ClienteSeleccionado);
			}
		}

		public Cliente SeleccionarPorID(Guid entidadId)

		{
			var ClienteSeleccionado = db.Clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
			return ClienteSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public Cliente SeleccionarPorNombre(string entidad)
		{
			var ClienteSeleccionado = db.Clientes.Where(c => c.Nombre == entidad).FirstOrDefault();
			return ClienteSeleccionado;
		}
	}
}
