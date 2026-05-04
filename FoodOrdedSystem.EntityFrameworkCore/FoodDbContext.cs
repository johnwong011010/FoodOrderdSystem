using FoodOrdedSystem.Domain;
using FoodOrdedSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace FoodOrdedSystem.EntityFrameworkCore
{
    /// <summary>
    /// You should add your database sets in here,In here I Imperment as SQL Server,you can change it as your DB type
    /// </summary>
    public class FoodDbContext : DbContext, IFoodDbContext
    {
        private DbSet<FoodItem> FoodItem { get; set; } = null!;
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Be aware you need to install the db package for db type,In below,you can define your data schema according to db.
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public async Task<IDbContextTransaction> BeginTranscationAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return await Database.BeginTransactionAsync(isolationLevel);
        }
    }
}
