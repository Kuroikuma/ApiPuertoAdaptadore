using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Cors;
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
	public class ProductoController : ControllerBase
	{

		public ProductoServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			IngredienteRepositorioSqlServer repositorioIngrediente = new IngredienteRepositorioSqlServer(db);
			ProductoRepositorioSqlServer repositorioProducto = new ProductoRepositorioSqlServer(db);
			CrearProductoRepositorioSqlServer repositorioCrearProducto = new CrearProductoRepositorioSqlServer(db);
			ProductoServicio servicio = new ProductoServicio(repositorioProducto, repositorioCrearProducto,repositorioIngrediente);

			return servicio;
		}

		// GET: api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet]
		public ActionResult<IEnumerable<Producto>> Get()
		{
			ProductoServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}



		// GET api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("{id}")]
		public ActionResult<Producto> Get(Guid id)
		{
			ProductoServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("Seleccionar/{id}")]
		public ActionResult GetCategoria(String id)
		{
			DbAmericanCheese context = new DbAmericanCheese();
			try
			{

				//var SeleccionarProducto = context.Producto.Where(s => s.IdCategoria == id).ToList();
				var SeleccionarProducto = (from c in context.Categoria
										   join pd in context.Producto on c.CategoriaID  equals pd.CategoriaID
										   where c.Nombre == id
										   select new
										   {
											   Categoria = c.Nombre,
											   CategoriaID=c.CategoriaID,
											   Producto = pd.Nombre,
											   ProductoID = pd.ProductoID,
											   Imagen = pd.Imagen,
											   Precio = pd.Precio,
											   Tamaño = pd.Tamaño,
											   Stock = pd.Stock,
											   IsStock = pd.isStock,
											   Ingrediente = (from cp in context.CrearProducto
															  join p in context.Producto on cp.ProductoID equals p.ProductoID
															  join i in context.Ingredientes on cp.IngredienteID equals i.IngredienteID
															  where cp.ProductoID == pd.ProductoID
															  select new
															  {
																  IngredienteID=i.IngredienteID,
																  Ingrediente = i.Nombre,
																  CantidadIngrediente = cp.CantidadIngrediente,
																  crearProducto=cp.CrearProductoID,
															  }).ToList()
										   }).ToList();
				return Ok(SeleccionarProducto);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}

		// POST api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPost]
		public ActionResult<Producto> Post([FromBody] Producto Entidad)
		{
			ProductoServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);
		
			
			return Ok(new Producto()
			{
				ProductoID = resultado.ProductoID,
				CategoriaID = resultado.CategoriaID,
				Nombre = resultado.Nombre,
				Precio = resultado.Precio,
				Stock = resultado.Stock,
				Tamaño = resultado.Tamaño,
				isStock = resultado.isStock,
				Imagen = resultado.Imagen,
				Descripcion = resultado.Descripcion,
				Costo = resultado.Costo,
		
		});
			
		}

		// PUT api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Producto Entidad)
		{
			ProductoServicio servicio = CrearServicio();

			Entidad.ProductoID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			ProductoServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
