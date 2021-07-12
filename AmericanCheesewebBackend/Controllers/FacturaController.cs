using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAmericanCheese.Infraestructura.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacturaController : ControllerBase
	{

		public FacturaServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			IngredienteRepositorioSqlServer repositorioIngrediente = new IngredienteRepositorioSqlServer(db);
			FacturaDetalleRepositorioSqlServer repositorioFacturaDetalle = new FacturaDetalleRepositorioSqlServer(db);
			FacturaRepositorioSqlServer repositorioFactura = new FacturaRepositorioSqlServer(db);
			ProductoRepositorioSqlServer repositorioProducto = new ProductoRepositorioSqlServer(db);
			CrearProductoRepositorioSqlServer repositorioCrearProducto = new CrearProductoRepositorioSqlServer(db);
			FacturaServicio servicio = new FacturaServicio(repositorioFactura, repositorioFacturaDetalle,repositorioProducto, repositorioIngrediente, repositorioCrearProducto );

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Factura>> Get()
		{
			FacturaServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Factura> Get(Guid id)
		{
			FacturaServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Factura> Post([FromBody] Factura Entidad)
		{
			FacturaServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}


		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			FacturaServicio servicio = CrearServicio();

			servicio.Anular(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
