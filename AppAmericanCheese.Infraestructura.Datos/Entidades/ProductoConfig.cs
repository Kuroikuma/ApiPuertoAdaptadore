using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AppAmericanCheese.Dominio;
using AppAmericanCheese.Dominio.Entidades;

namespace AppAmericanCheese.Infraestructura.Datos.Entidades
{
	class ProductoConfig : IEntityTypeConfiguration<Producto>
	{
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(P => P.ProductoID);
            builder.HasOne(producto => producto.categoriaNav)
             .WithMany(categoria => categoria.productosNav);

            builder.HasMany(producto => producto.crearProductosNav)
            .WithOne(crearProduc => crearProduc.productoNav);
        }

    }
}
