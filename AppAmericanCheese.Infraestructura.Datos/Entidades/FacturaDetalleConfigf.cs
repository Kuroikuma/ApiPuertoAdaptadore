using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.ToTable("FacturaDetalle");
            builder.HasKey(e => new { e.ProductoID, e.FacturaID })
                   .IsClustered(false);
            builder
              .HasOne(FD => FD.productoNav)
              .WithMany(P => P.facturaDetalleNav);
            builder
               .HasOne(FD => FD.facturaNav)
               .WithMany(F => F.facturaDetallesNav);
        }

    }
}
