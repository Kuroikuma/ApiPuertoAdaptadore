using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class IngredienteRepositorioSqlServer : IRepositorioNombre<Ingrediente, Guid, String>
	{

		private DbAmericanCheese db;

		public IngredienteRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

		public Ingrediente Agregar(Ingrediente ingrediente)
		{
			ingrediente.IngredienteID = Guid.NewGuid();

			db.Ingredientes.Add(ingrediente);

			return ingrediente;
		}

		public List<Ingrediente> Listar()
		{
			return db.Ingredientes.ToList();
		}

		public void Editar(Ingrediente ingrediente)
		{
			var ingredienteSeleccionado = db.Ingredientes.Where(c => c.IngredienteID == ingrediente.IngredienteID).FirstOrDefault();
			if (ingredienteSeleccionado != null)
			{
				ingredienteSeleccionado.Nombre = ingrediente.Nombre;
				ingredienteSeleccionado.precio = ingrediente.precio;
				ingredienteSeleccionado.Stock = ingrediente.Stock;
				ingredienteSeleccionado.Imagen = ingrediente.Imagen;

				db.Entry(ingredienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var ingredienteSeleccionado = db.Ingredientes.Where(c => c.IngredienteID == entidadId).FirstOrDefault();
			if (ingredienteSeleccionado != null)
			{
				db.Ingredientes.Remove(ingredienteSeleccionado);
			}
		}

		public Ingrediente SeleccionarPorID(Guid entidadId)

		{
			var IngredienteSeleccionado = db.Ingredientes.Where(c => c.IngredienteID == entidadId).FirstOrDefault();
			return IngredienteSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public Ingrediente SeleccionarPorNombre(string entidad)
		{
			var IngredienteSeleccionado = db.Ingredientes.Where(c => c.Nombre == entidad).FirstOrDefault();
			return IngredienteSeleccionado;
		}


	}
}
