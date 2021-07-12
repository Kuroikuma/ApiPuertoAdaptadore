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
	public class ClienteController : ControllerBase
	{

		public ClienteServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			ClienteRepositorioSqlServer repositorio = new ClienteRepositorioSqlServer(db);

			ClienteServicio servicio = new ClienteServicio(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Cliente>> Get()
		{
			ClienteServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Categoria> Get(Guid id)
		{
			ClienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Producto> Post([FromBody] Cliente Entidad)
		{
			ClienteServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Cliente Entidad)
		{
			ClienteServicio servicio = CrearServicio();

			Entidad.ClienteID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			ClienteServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
