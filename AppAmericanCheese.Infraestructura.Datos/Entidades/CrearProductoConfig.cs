using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class CrearProductoConfig : IEntityTypeConfiguration<CrearProducto>
    {
        public void Configure(EntityTypeBuilder<CrearProducto> builder)
        {
            builder.ToTable("CrearProducto");
            builder.HasKey(CR => CR.CrearProductoID);
            builder
              .HasOne(crearProducto => crearProducto.productoNav)
              .WithMany(producto => producto.crearProductosNav);
            builder
               .HasOne(crearProducto => crearProducto.ingredienteNav)
               .WithMany(ingrediente => ingrediente.crearProductosNav);
        }

    }
}
