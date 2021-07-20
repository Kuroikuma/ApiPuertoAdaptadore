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
	public class EmpleadoController : ControllerBase
	{

		public EmpleadoServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			EmpleadoRepositorioSqlServer repositorio = new EmpleadoRepositorioSqlServer(db);

			EmpleadoServicio servicio = new EmpleadoServicio(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Empleado>> Get()
		{
			EmpleadoServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Empleado> Get(Guid id)
		{
			EmpleadoServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[HttpGet("Seleccionar/{id}")]
		public ActionResult<Empleado> GetSelect(string id)
		{
            try
            {
				DbAmericanCheese db = new DbAmericanCheese();
				var EmpleadoSeleccionado = db.Empleado.Where(c => c.Correo == id).FirstOrDefault();
				EmpleadoServicio servicio = CrearServicio();
				return Ok(servicio.SeleccionarPorID(EmpleadoSeleccionado.EmpleadoID));
			}
            catch (Exception)
            {

				return null;
            }
			
		}
		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Empleado> Post([FromBody] Empleado Entidad)
		{
			EmpleadoServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Empleado Entidad)
		{
			EmpleadoServicio servicio = CrearServicio();

			Entidad.EmpleadoID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			EmpleadoServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
