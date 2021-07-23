using AppAmericanCheese.Dominio;
using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    public class RootConfig : IEntityTypeConfiguration<Root>
    {
        public void Configure(EntityTypeBuilder<Root> builder)
        {
            builder.HasKey(A => A.RootID);

            builder.ToTable("Root");
        }

    }
}
