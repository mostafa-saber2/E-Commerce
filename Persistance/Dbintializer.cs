// Persistance/Dbintializer.cs
using System.Text.Json;
using Domain;
using Domain.Contracts;
using Domain.Entities;
using Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;

namespace Persistance
{
    public class Dbintializer : IDbintializer
    {
        private readonly StoreContext _storeContext;

        public Dbintializer(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task IntializeAsync()
        {
            try
            {
                #region forupdatingdatabase
                if (_storeContext.Database.GetPendingMigrations().Any())
                {
                    await _storeContext.Database.MigrateAsync();
                }
                #endregion

                #region productbrand
                if (!_storeContext.ProductBrands.Any())
                {
                    var BrandsData = await File.ReadAllTextAsync("C:\\Users\\HP\\source\\repos\\E-Commerce\\Persistance\\Data\\Seeding\\brands.json");
                    var Brands = JsonSerializer.Deserialize<List<Productbrand>>(BrandsData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (Brands is not null && Brands.Any())
                    {
                        await _storeContext.ProductBrands.AddRangeAsync(Brands);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                #endregion

                #region producttypes
                if (!_storeContext.ProductTypes.Any())
                {
                    var TypesData = await File.ReadAllTextAsync(@"C:\\Users\\HP\\source\\repos\\E-Commerce\\Persistance\\Data\\Seeding\\types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (Types is not null && Types.Any())
                    {
                        await _storeContext.ProductTypes.AddRangeAsync(Types);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                #endregion

                #region products
                if (!_storeContext.Products.Any())
                {
                    var ProductsData = await File.ReadAllTextAsync("C:\\Users\\HP\\source\\repos\\E-Commerce\\Persistance\\Data\\Seeding\\products.json");
                    var Productss = JsonSerializer.Deserialize<List<Product>>(ProductsData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (Productss is not null && Productss.Any())
                    {
                        await _storeContext.Products.AddRangeAsync(Productss);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
