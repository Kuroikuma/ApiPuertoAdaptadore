using AppAmericanCheese.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
    class AdministradorConfig : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.HasKey(A => A.AdministradorID);

            builder.ToTable("Administrador");
        }

    }
}
