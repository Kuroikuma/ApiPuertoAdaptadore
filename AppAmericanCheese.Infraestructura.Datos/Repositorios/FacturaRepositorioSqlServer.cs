using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class FacturaRepositorioSqlServer : IRepositorioMovimiento<Factura, Guid>
	{

		private DbAmericanCheese db;

		public FacturaRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

		public Factura Agregar(Factura Entidad)
		{
			Entidad.FacturaID = Guid.NewGuid();

			db.Factura.Add(Entidad);

			return Entidad;
		}

		public List<Factura> Listar()
		{
			return db.Factura.ToList();
		}

		public Factura SeleccionarPorID(Guid entidadId)

		{
			var EntidadSeleccionado = db.Factura.Where(c => c.FacturaID == entidadId).FirstOrDefault();
			return EntidadSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

        public void Anular(Guid entidadId)
        {
			var ventaSeleccionada = SeleccionarPorID(entidadId);

			if (ventaSeleccionada != null)
			{
				ventaSeleccionada.anulado = true;

				db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			else
			{
				throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
			}
		}
    }
}
