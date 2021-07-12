using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AppAmericanCheese.Dominio;
using AppAmericanCheese.Dominio.Entidades;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(e => e.CategoriaID);

            builder.ToTable("Categoria");
            builder
                .HasMany(categoria => categoria.productosNav)
                .WithOne(producto => producto.categoriaNav);
        }

    }
}
