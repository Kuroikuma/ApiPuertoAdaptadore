using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(F => F.FacturaID );
            builder
              .HasOne(F => F.clienteNav)
              .WithMany(C => C.facturasNav);
            builder
               .HasOne(F => F.empleadoNav)
               .WithMany(E => E.facturasNav);
            builder
             .HasMany(F => F.facturaDetallesNav)
             .WithOne(FD => FD.facturaNav);
        }

    }
}
