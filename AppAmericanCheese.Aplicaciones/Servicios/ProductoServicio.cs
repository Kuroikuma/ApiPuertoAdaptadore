using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using AppAmericanCheese.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
	public class ProductoServicio : IServicioNombre<Producto, Guid,String>
	{

		private readonly IRepositorioNombre<Producto, Guid,String> repositorioProducto;
		private readonly IRepositorioBase<CrearProducto, Guid> repositorioCrearProducto;
		private readonly IRepositorioNombre<Ingrediente, Guid, String> repositorioIngrediente;

		public ProductoServicio(IRepositorioNombre<Producto, Guid, String> _repositorioProducto,
								IRepositorioBase<CrearProducto, Guid> _repositorioCrearProducto,
								IRepositorioNombre<Ingrediente, Guid, String> _repositorioIngrediente
		)
		{

			repositorioProducto = _repositorioProducto;
			repositorioCrearProducto = _repositorioCrearProducto;
			repositorioIngrediente = _repositorioIngrediente;
		}

		public Producto Agregar(Producto entidad)
		{
			var ProductoAgregada = repositorioProducto.Agregar(entidad);

			if (ProductoAgregada.Nombre == "" || ProductoAgregada.Nombre == null || ProductoAgregada.Precio == 0 || ProductoAgregada.Tamaño==null || ProductoAgregada.Tamaño == "")
			{
				throw new Exception("error");
			}

			if (entidad.isCompound==true)
            {
				entidad.crearProductosNav.ForEach(crearProducto => {
					var IngredienteSeleccionado = repositorioIngrediente.SeleccionarPorID(crearProducto.IngredienteID);
					if (IngredienteSeleccionado == null)
						throw new NullReferenceException("Usted está intentando hacer una pizza con un ingrediente que no exite 😡😡😡...");
				
					crearProducto.ProductoID = entidad.ProductoID;
				
					crearProducto.CostoDeIngredientes = IngredienteSeleccionado.precio * crearProducto.CantidadIngrediente;
					entidad.Costo += crearProducto.CostoDeIngredientes;
					repositorioCrearProducto.Agregar(crearProducto);
					repositorioProducto.Editar(entidad);
				});
			}
			
			repositorioProducto.GuardarTodosLosCambios();
			return entidad;
		}

		public List<Producto> Listar()
		{
			return repositorioProducto.Listar();
		}

		public void Editar(Producto entidad)
		{
			
			DbAmericanCheese db = new DbAmericanCheese();
			var productoSeleccionado = db.Producto.Where(c => c.ProductoID == entidad.ProductoID).FirstOrDefault();

			if (entidad.Precio == null || entidad.Precio == 0)
			{
				productoSeleccionado.Precio = productoSeleccionado.Precio;
			}
			else
			{
				productoSeleccionado.Precio = (productoSeleccionado.Precio + entidad.Precio) / 2;
			}


			if (entidad.isCompound == true)
			{
				entidad.crearProductosNav.ForEach(crearProducto => {
					var IngredienteSeleccionado = repositorioIngrediente.SeleccionarPorID(crearProducto.IngredienteID);
					if (IngredienteSeleccionado == null)
						throw new NullReferenceException("Usted está intentando hacer una pizza con un ingrediente que no exite 😡😡😡...");

					crearProducto.ProductoID = entidad.ProductoID;

					crearProducto.CostoDeIngredientes = IngredienteSeleccionado.precio * crearProducto.CantidadIngrediente;
					productoSeleccionado.Costo += crearProducto.CostoDeIngredientes;
                    if (crearProducto.CrearProductoID == null) repositorioCrearProducto.Agregar(crearProducto); 
					else repositorioCrearProducto.Editar(crearProducto);

				
					
					repositorioProducto.Editar(productoSeleccionado);
				});
            }
            else { repositorioProducto.Editar(entidad); }

			repositorioProducto.GuardarTodosLosCambios();
			
		}

		public void Eliminar(Guid entidadId)
		{
			repositorioProducto.Eliminar(entidadId);
			repositorioProducto.GuardarTodosLosCambios();
		}

		public Producto SeleccionarPorID(Guid entidadId)
		{
			return repositorioProducto.SeleccionarPorID(entidadId);
		}

        public Producto SeleccionarPorNombre(string entidad)
        {
			return repositorioProducto.SeleccionarPorNombre(entidad);
		}

        public void GuardarTodosLosCambios()
        {
			repositorioProducto.GuardarTodosLosCambios();
		}
    }
}
