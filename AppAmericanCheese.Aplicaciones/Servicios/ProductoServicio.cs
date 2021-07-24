using AppAmericanCheese.Aplicaciones.Interfaces;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
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
            

            if (entidad.isStock==false)
            {
				entidad.crearProductosNav.ForEach(crearProducto => {
					var IngredienteSeleccionado = repositorioIngrediente.SeleccionarPorID(crearProducto.IngredienteID);
					if (IngredienteSeleccionado == null)
						throw new NullReferenceException("Usted está intentando hacer una pizza con un ingrediente que no exite 😡😡😡...");
				
					crearProducto.ProductoID = entidad.ProductoID;
				
					crearProducto.CostoDeIngredientes = IngredienteSeleccionado.precio * crearProducto.CantidadIngrediente;
					entidad.Costo = entidad.Costo + crearProducto.CostoDeIngredientes;
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
			 repositorioProducto.Editar(entidad);


			if (entidad.isStock == false)
			{
				entidad.crearProductosNav.ForEach(crearProducto => {
					var IngredienteSeleccionado = repositorioIngrediente.SeleccionarPorID(crearProducto.IngredienteID);
					if (IngredienteSeleccionado == null)
						throw new NullReferenceException("Usted está intentando hacer una pizza con un ingrediente que no exite 😡😡😡...");

					crearProducto.ProductoID = entidad.ProductoID;

					crearProducto.CostoDeIngredientes = IngredienteSeleccionado.precio * crearProducto.CantidadIngrediente;
					entidad.Costo = entidad.Costo + crearProducto.CostoDeIngredientes;
                    if (crearProducto.CrearProductoID == null) repositorioCrearProducto.Agregar(crearProducto); 
					else repositorioCrearProducto.Editar(crearProducto);

				
					
					repositorioProducto.Editar(entidad);
				});
			}

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
