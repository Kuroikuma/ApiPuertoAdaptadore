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
	public class IngredienteController : ControllerBase
	{

		public IngredienteServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			IngredienteRepositorioSqlServer repositorio = new IngredienteRepositorioSqlServer(db);

			IngredienteServicio servicio = new IngredienteServicio(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Ingrediente>> Get()
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Ingrediente> Get(Guid id)
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}
		

		[HttpGet("Selecionar/{id}")]
		public ActionResult<String> Get(string id)
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}


		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Ingrediente> Post([FromBody] Ingrediente Entidad)
		{
			IngredienteServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Ingrediente Entidad)
		{
			IngredienteServicio servicio = CrearServicio();

			Entidad.IngredienteID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			IngredienteServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
