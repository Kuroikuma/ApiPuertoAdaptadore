using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppAmericanCheese.Aplicaciones.Interfaces;

namespace AppAmericanCheese.Aplicaciones.Servicios
{
	public class FacturaServicio : IServicioMovimiento<Factura, Guid>
	{

		private readonly IRepositorioMovimiento<Factura, Guid> repositorioFactura;
		private readonly IRepositorioNombre<Producto, Guid,String> repositorioProducto;
		private readonly IRepositorioDetalle<FacturaDetalle, Guid> repositorioDetalle;
		private readonly IRepositorioBase<CrearProducto, Guid> repositorioCrearProducto;
		private readonly IRepositorioNombre<Ingrediente, Guid, String> repositorioIngrediente;

		public FacturaServicio(
			IRepositorioMovimiento<Factura, Guid> _repositorioVenta,
			IRepositorioDetalle<FacturaDetalle, Guid> _repositorioDetalle,
			IRepositorioNombre<Producto, Guid,String> _repositorioProducto,
			IRepositorioNombre<Ingrediente, Guid, String> _repositorioIngrediente,
			IRepositorioBase<CrearProducto, Guid> _repositorioCrearProducto
		)
		{
			repositorioFactura = _repositorioVenta;
			repositorioDetalle = _repositorioDetalle;
			repositorioProducto = _repositorioProducto;
			repositorioIngrediente = _repositorioIngrediente;
			repositorioCrearProducto = _repositorioCrearProducto;
		}

		public Factura Agregar(Factura entidad)
		{
			var ventaAgregada = repositorioFactura.Agregar(entidad);

			entidad.facturaDetallesNav.ForEach(detalle => {
				var productoSeleccionado = repositorioProducto.SeleccionarPorID(detalle.ProductoID);
				if (productoSeleccionado == null)
					throw new NullReferenceException("Usted está intentando vender un producto que no existe 😡😡😡...");

				detalle.FacturaID = entidad.FacturaID;
				detalle.CostoProductosVendido = productoSeleccionado.Costo * detalle.CatidadProductosVendido;
				detalle.PrecioProductosVendido = productoSeleccionado.Precio * detalle.CatidadProductosVendido;
				
				repositorioDetalle.Agregar(detalle);
                if (productoSeleccionado.isCompound==true)
                {
					productoSeleccionado.Stock -= detalle.CatidadProductosVendido;
					repositorioProducto.Editar(productoSeleccionado);
				}
                else
                {
					List<CrearProducto> crearProducto = repositorioCrearProducto.SeleccionarDetallesPorMovimiento(productoSeleccionado.ProductoID);
					crearProducto.ForEach(item =>{
						Ingrediente ingrediente = repositorioIngrediente.SeleccionarPorID(item.IngredienteID);
						ingrediente.Stock -= item.CantidadIngrediente * detalle.CatidadProductosVendido;
						repositorioIngrediente.Editar(ingrediente);
						});
					}
				entidad.Total += detalle.PrecioProductosVendido;
			});

			repositorioFactura.GuardarTodosLosCambios();
			return ventaAgregada;
		}

		public void Anular(Guid ventaId)
		{
			repositorioFactura.Anular(ventaId);
			repositorioFactura.GuardarTodosLosCambios();
		}

		public List<Factura> Listar()
		{
			return repositorioFactura.Listar();
		}

		public Factura SeleccionarPorID(Guid ventaId)
		{
			return repositorioFactura.SeleccionarPorID(ventaId);
		}
	}
}
