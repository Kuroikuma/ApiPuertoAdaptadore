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
using AppAmericanCheese.Dominio;
using Microsoft.AspNetCore.Cors;

namespace AppAmericanCheese.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        public RootServicio CrearServicio()
        {
            DbAmericanCheese db = new DbAmericanCheese();
            RootRepositorioSqlServer repositorio = new RootRepositorioSqlServer(db);

            RootServicio servicio = new RootServicio(repositorio);

            return servicio;
        }

        // GET: api/Root
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public ActionResult<Root> Get()
        {
            RootServicio servicio = CrearServicio();

            return Ok(servicio.Listar());
        }

        // GET: api/Root/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}", Name = "GetRoot")]
        public ActionResult<Root> Get(Guid id)
        {
            RootServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id)); ;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("Seleccionar/{correo}/{contraseña}")]
        public ActionResult<Root> GetSelect(string correo, string contraseña)
        {
            try
            {
                DbAmericanCheese db = new DbAmericanCheese();
                var RootSeleccionado = db.Root.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
                RootServicio servicio = CrearServicio();

                return Ok(servicio.SeleccionarPorID(RootSeleccionado.RootID));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST: api/Root
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public ActionResult<Root> Post([FromBody] Root entidad)
        {
            RootServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(entidad);

            return Ok(resultado);
        }

        // PUT: api/Root/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        public ActionResult<Root> Put(Guid id, [FromBody] Root entidad)
        {
            entidad.RootID = id;

            RootServicio servicio = CrearServicio();

            servicio.Editar(entidad);

            return Ok("Editado Exitosamente");
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public ActionResult<Root> Delete(Guid id)
        {
            RootServicio servicio = CrearServicio();

            servicio.Eliminar(id);
            return Ok("Eliminado Satisfactoriamente");
        }
    }
}

