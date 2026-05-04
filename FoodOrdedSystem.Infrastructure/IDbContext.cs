using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FoodOrdedSystem.Infrastructure
{
    public interface IDbContext
    {
        Task<IDbContext> BeginTranscationAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<T> Set<T>() where T : class;
    }
}
