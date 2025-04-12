
using Domain.Contracts;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            #region configure services
            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<IDbintializer, Persistance.Dbintializer>();

            #endregion



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await IntializeDbAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            async Task IntializeDbAsync(WebApplication webApplication)
            {
                //create object from type that implements IDbIntializer
                using var Scope=app.Services.CreateScope();
                var DBIntializer=Scope.ServiceProvider.GetRequiredService<IDbintializer>();
                await DBIntializer.IntializeAsync();
            }
        }
    }
}
