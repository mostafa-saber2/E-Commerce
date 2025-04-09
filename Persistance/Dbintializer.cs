using System.Text.Json;
using Domain;
using Domain.Contracts;
using Domain.Entities;
using Persistance.Data;
using Microsoft.EntityFrameworkCore; // مهم عشان Database.MigrateAsync()
                                     // مهم عشان IMigrator


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
                // create db if doesn't exist and apply any pending migrations
                if (_storeContext.Database.GetPendingMigrations().Any())
                {
                    await _storeContext.Database.MigrateAsync();
                }
                #endregion



                #region products
                if (!_storeContext.Products.Any())
                {
                    //read types from file as string 
                    var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeding\products.json");
                    //transform into c# object type
                    var Productss = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    //add to database and savechanges
                    if (Productss is not null && Productss.Any())
                    {
                        await _storeContext.Products.AddRangeAsync(Productss);
                        await _storeContext.SaveChangesAsync();
                    }
                }
                #endregion
                #region productbrand
                if (!_storeContext.ProductBrands.Any())
                {
                    //read types from file as string 
                    var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeding\brands.json");
                    //transform into c# object type
                    var Brands = JsonSerializer.Deserialize<List<Productbrand>>(BrandsData);
                    //add to database and savechanges
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
                    //read types from file as string 
                    var TypesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\Seeding\types.json");
                    //transform into c# object type
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    //add to database and savechanges
                    if (Types is not null && Types.Any())
                    {
                        await _storeContext.ProductTypes.AddRangeAsync(Types);
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
