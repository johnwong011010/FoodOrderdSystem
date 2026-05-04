using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace FoodOrdedSystem.Infrastructure
{
    public interface IFoodDbContext
    {
        Task<IDbContextTransaction> BeginTranscationAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<T> Set<T>() where T : class;
    }
}
