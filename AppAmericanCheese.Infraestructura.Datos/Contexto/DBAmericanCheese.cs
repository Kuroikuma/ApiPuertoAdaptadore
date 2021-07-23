using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using AppAmericanCheese.Infraestructura.Datos.Entidades;
using AppAmericanCheese.Dominio.Entidades;
using AppAmericanCheese.Infraestructura.Datos.Helper;
using AppAmericanCheese.Dominio;

namespace AppAmericanCheese.Infraestructura.Datos
{
    public class DbAmericanCheese : DbContext
    {

        public DbSet <Administrador> Administrador { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CrearProducto> CrearProducto { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Root> Root { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfiguracionGlobal.SqlServerConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CrearProductoConfig());
            modelBuilder.ApplyConfiguration(new AdministradorConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new FacturaConfig());
            modelBuilder.ApplyConfiguration(new FacturaDetalleConfig());
            modelBuilder.ApplyConfiguration(new IngredienteConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new RootConfig());
        }
    }
}
