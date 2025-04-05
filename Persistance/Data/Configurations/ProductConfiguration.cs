using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistance.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(Product => Product.productbrand)
                .WithMany()
                .HasForeignKey(Product => Product.BrandId);


            builder.HasOne(Product => Product.productType)
           .WithMany()
           .HasForeignKey(Product => Product.TypeId);




          //  builder.Property(Product => Product.Price)
          //.HasColumnType("decimal(18,2)");





        }
    }
}
