using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Data
{
    public class StoreContext : DbContext

    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet <Product> Products { get; set; }
        public DbSet <Productbrand> ProductBrands { get; set; }
        public DbSet <ProductType> ProductTypes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
        }

    }
}
