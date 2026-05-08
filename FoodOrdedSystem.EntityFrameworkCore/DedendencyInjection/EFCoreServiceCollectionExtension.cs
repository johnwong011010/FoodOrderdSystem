using FoodOrdedSystem.Domain;
using FoodOrdedSystem.Domain.Repository;
using FoodOrdedSystem.EntityFrameworkCore.Repository;
using FoodOrdedSystem.Infrastructure;
using FoodOrdedSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdedSystem.EntityFrameworkCore.DedendencyInjection
{
    public static class EFCoreServiceCollectionExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration;
            var cs = configuration.GetConnectionString("Default");
            services.AddDbContext<FoodDbContext>(sp => sp.UseSqlServer(cs));//you can change to other database provider here
            services.TryAddScoped<IFoodDbContext>(sp =>
            {
                var dbContext = sp.GetRequiredService<FoodDbContext>();
                if (dbContext.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                {
                    dbContext.Database.OpenConnection();
                }
                return dbContext;
            });
            services.TryAddScoped<IFoodItemRepository, FoodItemRepository>();

            services.TryAddScoped<IRepository<FoodItem>, FoodItemRepository>();

            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
