﻿using AppAmericanCheese.Aplicaciones.Servicios;
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
	public class CategoriaController : ControllerBase
	{

		public CategoriaServicio CrearServicio()
		{
			DbAmericanCheese db = new DbAmericanCheese();
			CategoriaRepositorioSqlServer repositorio = new CategoriaRepositorioSqlServer(db);

			CategoriaServicio servicio = new CategoriaServicio(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet]
		public ActionResult<IEnumerable<Categoria>> Get()
		{
			CategoriaServicio servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("{id}")]
		public ActionResult<Categoria> Get(Guid id)
		{
			CategoriaServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[EnableCors("_myAllowSpecificOrigins")]
		[HttpGet("Selecionar/{id}")]
		public ActionResult<String> Get(string id)
		{
			CategoriaServicio servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}

		// POST api/<ProductoController>
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPost]
		public ActionResult<Categoria> Post([FromBody] Categoria Entidad)
		{
			CategoriaServicio servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Categoria Entidad)
		{
			CategoriaServicio servicio = CrearServicio();

			Entidad.CategoriaID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[EnableCors("_myAllowSpecificOrigins")]
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			CategoriaServicio servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
