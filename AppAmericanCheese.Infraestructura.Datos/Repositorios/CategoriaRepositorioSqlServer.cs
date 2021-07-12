using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using AppAmericanCheese.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class CategoriaRepositorioSqlServer : IRepositorioNombre<Categoria, Guid, String>
	{

		private DbAmericanCheese db;

		public CategoriaRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

		public Categoria Agregar(Categoria Categoria)
		{
			Categoria.CategoriaID = Guid.NewGuid();

			db.Categoria.Add(Categoria);

			return Categoria;
		}

		public List<Categoria> Listar()
		{
			return db.Categoria.ToList();
		}

		public void Editar(Categoria Categoria)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == Categoria.CategoriaID).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				CategoriaSeleccionado.Nombre = Categoria.Nombre;
				CategoriaSeleccionado.Descripcion = Categoria.Descripcion;

				db.Entry(CategoriaSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				db.Categoria.Remove(CategoriaSeleccionado);
			}
		}

		public Categoria SeleccionarPorID(Guid entidadId)

		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			return CategoriaSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}
			
		public Categoria SeleccionarPorNombre(string entidad)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.Nombre == entidad).FirstOrDefault();
			return CategoriaSeleccionado;
		}
	}
}
