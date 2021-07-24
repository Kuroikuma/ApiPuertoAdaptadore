using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppAmericanCheese.Aplicaciones.Servicios;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos;
using AppAmericanCheese.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Cors;

namespace AppAmericanCheese.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        public AdministradorServicio CrearServicio()
        {
            DbAmericanCheese db = new DbAmericanCheese();
            AdministradorRepositorioSqlServer repositorio = new AdministradorRepositorioSqlServer(db);

            AdministradorServicio servicio = new AdministradorServicio(repositorio);

            return servicio;
        }

        // GET: api/Administrador
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public ActionResult<Administrador> Get()
        {
            AdministradorServicio servicio = CrearServicio();

            return Ok(servicio.Listar());
        }

        // GET: api/Administrador/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Administrador> Get(Guid id)
        {
            AdministradorServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id)); ;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("Seleccionar/{correo}/{contraseña}")]
        public ActionResult<Administrador> GetSelect(string correo, string contraseña)
        {
            try
            {
                DbAmericanCheese db = new DbAmericanCheese();
                var AdministradorSeleccionado = db.Administrador.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
                AdministradorServicio servicio = CrearServicio();

                return Ok(servicio.SeleccionarPorID(AdministradorSeleccionado.AdministradoID));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST: api/Administrador
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public ActionResult <Administrador> Post([FromBody] Administrador entidad)
        {
            AdministradorServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(entidad);

            return Ok(resultado);
        }

        // PUT: api/Administrador/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        public ActionResult <Administrador> Put(Guid id, [FromBody] Administrador entidad)
        {
            entidad.AdministradoID = id;

            AdministradorServicio servicio = CrearServicio();

            servicio.Editar(entidad);

            return Ok("Editado Exitosamente");
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public ActionResult <Administrador> Delete(Guid id)
        {
            AdministradorServicio servicio = CrearServicio();

            servicio.Eliminar(id);
            return Ok("Eliminado Satisfactoriamente");
        }
    }
}
