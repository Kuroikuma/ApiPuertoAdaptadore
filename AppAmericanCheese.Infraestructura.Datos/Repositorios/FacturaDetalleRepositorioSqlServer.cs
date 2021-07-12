using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Repositorios
{
	public class FacturaDetalleRepositorioSqlServer : IRepositorioDetalle<FacturaDetalle, Guid>
	{

		private DbAmericanCheese db;

		public FacturaDetalleRepositorioSqlServer(DbAmericanCheese _db)
		{
			db = _db;
		}

        public FacturaDetalle Agregar(FacturaDetalle entidad)
        {

            db.FacturaDetalle.Add(entidad);

            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<FacturaDetalle> SeleccionarDetallesPorMovimiento(Guid movimientoId)
        {
            return db.FacturaDetalle.Where(c => c.FacturaID == movimientoId).ToList();
        }
    }
}
