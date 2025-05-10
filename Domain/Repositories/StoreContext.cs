using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class StoreContext : DbContext // لا تستخدم static هنا
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        // DbSet لتخزين الكيانات
        public DbSet<Product> Products { get; set; }
        public DbSet<Productbrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        // تخصيص النماذج (ModelBuilder) عند بناء قاعدة البيانات
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}
