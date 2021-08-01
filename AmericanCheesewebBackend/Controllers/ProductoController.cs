using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		private List<Producto> _Producto;
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


		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("Selecionar/Producto/{buscar}")]
		public ActionResult<String> Get(string buscar)
		{
			DbAmericanCheese context = new DbAmericanCheese();
			try
			{
				
				_Producto = context.Producto.ToList();
				//var SeleccionarProducto = context.Producto.Where(s => s.IdCategoria == id).ToList();
				if (!string.IsNullOrEmpty(buscar))
				{
					foreach (var item in buscar.Split(new char[] { ' ' },
							 StringSplitOptions.RemoveEmptyEntries))
					{
						_Producto = _Producto.Where(x => x.Nombre.Contains(item)).ToList();
					
					};
				}
				var resultado = _Producto.Join(context.Categoria,
							Producto => Producto.CategoriaID,
							Categoria => Categoria.CategoriaID ,
							(Producto, Categoria) => new
							{
								Categoria = Categoria.Nombre,
								CategoriaID = Producto.CategoriaID,
								Nombre = Producto.Nombre,
								ProductoID = Producto.ProductoID,
								Imagen = Producto.Imagen,
								Precio = Producto.Precio,
								Tamaño = Producto.Tamaño,
								Ingrediente = (from cp in context.CrearProducto
											   join p in context.Producto on cp.ProductoID equals p.ProductoID
											   join i in context.Ingredientes on cp.IngredienteID equals i.IngredienteID
											   where cp.ProductoID == Producto.ProductoID
											   select new
											   {
												   IngredienteID = i.IngredienteID,
												   Ingrediente = i.Nombre,
												   CantidadIngrediente = cp.CantidadIngrediente,
												   crearProducto = cp.CrearProductoID,
											   }).ToList()

							}
						).ToList();
				return Ok(resultado);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
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
											   Nombre = pd.Nombre,
											   ProductoID = pd.ProductoID,
											   Imagen = pd.Imagen,
											   Precio = pd.Precio,
											   Tamaño = pd.Tamaño,
											   Stock = pd.Stock,
											   isCompound = pd.isCompound,
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
		public ActionResult<String> Post([FromBody] Producto Entidad)
		{
			try
			{
				ProductoServicio servicio = CrearServicio();

				var resultado = servicio.Agregar(Entidad);

				return Ok("success");
			}
			catch (Exception e)
			{
				return BadRequest("error");
			}

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
