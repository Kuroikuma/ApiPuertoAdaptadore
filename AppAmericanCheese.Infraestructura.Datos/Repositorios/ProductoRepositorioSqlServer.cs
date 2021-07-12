using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class ProductoRepositorioSqlServer : IRepositorioNombre<Producto, Guid, String>
	{

		private DbAmericanCheese db;

		public ProductoRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

		public Producto Agregar(Producto producto)
		{

			producto.ProductoID = Guid.NewGuid();
			db.Producto.Add(producto);

			return producto;
		}

		public List<Producto> Listar()
		{
			return db.Producto.ToList();
		}

		public void Editar(Producto producto)
		{
			var productoSeleccionado = db.Producto.Where(c => c.ProductoID == producto.ProductoID).FirstOrDefault();
			if (productoSeleccionado != null)
			{
				productoSeleccionado.Nombre = producto.Nombre;
				productoSeleccionado.Descripcion = producto.Descripcion;
				productoSeleccionado.Precio = producto.Precio;
				productoSeleccionado.Costo = producto.Costo;
				productoSeleccionado.Imagen = producto.Imagen;

				db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var productoSeleccionado = db.Producto.Where(c => c.ProductoID == entidadId).FirstOrDefault();
			if (productoSeleccionado != null)
			{
				db.Producto.Remove(productoSeleccionado);
			}
		}

		public Producto SeleccionarPorID(Guid entidadId)
		{
			var productoSeleccionado = db.Producto.Where(c => c.ProductoID == entidadId).FirstOrDefault();
			return productoSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

        public Producto SeleccionarPorNombre(string entidad)
        {
			var productoSeleccionado = db.Producto.Where(c => c.Nombre == entidad).FirstOrDefault();
			return productoSeleccionado;
		}

       
    }
}
