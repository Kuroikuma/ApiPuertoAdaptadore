using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet]
		public ActionResult<IEnumerable<Cliente>> Get()
		{
			ClienteServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("{id}")]
		public ActionResult<Cliente> Get(Guid id)
		{
	
			ClienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("Seleccionar/{correo}/{contraseña}")]
		public ActionResult<Cliente> GetSelect(string correo, string contraseña)
		{
            try
            {
				DbAmericanCheese db = new DbAmericanCheese();
				var ClienteSeleccionado = db.Clientes.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
				ClienteServicio servicio = CrearServicio();

				return Ok(servicio.SeleccionarPorID(ClienteSeleccionado.ClienteID));
			}
            catch (Exception e)
            {

				return BadRequest(e.Message);
            }
			
		}
		// POST api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPost]
		public ActionResult<Cliente> Post([FromBody] Cliente cliente)
		{

			var base64array = Convert.FromBase64String(cliente.Imagen);
			Guid name = Guid.NewGuid();
			string filePashString = $"Content/img/{name}.png";

			var filePath = Path.Combine($"Content/img/{name}.png");
			System.IO.File.WriteAllBytes(filePath, base64array);
			
			/*
						if (client_File.files.Count>0)
						{

								var filePath = "C:\\Users\\Arleys Gatica\\ApiPuertoAdaptadore\\AmericanCheesewebBackend\\Content\\img" + file.FileName;

								using (var stream = System.IO.File.Create(filePath))
								{
									file.CopyToAsync(stream);
								}
								client_File.Entidad.Imagen = "Content\\img" + file.FileName;

						}
				*/
			ClienteServicio servicio = CrearServicio();
			cliente.Imagen = filePashString;
			var resultado = servicio.Agregar(cliente);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Cliente Entidad)
		{
			ClienteServicio servicio = CrearServicio();

			Entidad.ClienteID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			ClienteServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
