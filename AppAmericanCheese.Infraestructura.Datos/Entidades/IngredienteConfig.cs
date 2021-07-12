using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class IngredienteConfig : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.ToTable("Ingrediente");
            builder.HasKey(e => e.IngredienteID);
            builder
              .HasMany(E => E.crearProductosNav)
              .WithOne(CR => CR.ingredienteNav);
        }

    }
}
