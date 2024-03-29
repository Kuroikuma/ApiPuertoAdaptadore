﻿using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
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
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet]
		public ActionResult<IEnumerable<Ingrediente>> Get()
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("{id}")]
		public ActionResult<Ingrediente> Get(Guid id)
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("Selecionar/{id}")]
		public ActionResult<String> Get(string id)
		{
			IngredienteServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}


		// POST api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPost]
		public ActionResult<String> Post([FromBody] Ingrediente Entidad)
		{
			try
			{
					IngredienteServicio servicio = CrearServicio();
		
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
		public ActionResult<String> Put(Guid id, [FromBody] Ingrediente Entidad)
		{
			try
			{
				IngredienteServicio servicio = CrearServicio();

				Entidad.IngredienteID = id;

				servicio.Editar(Entidad);

				return Ok("success");
			}
			catch(Exception e)
			{
				return BadRequest("error");
			}
			
		}

		// DELETE api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			IngredienteServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
