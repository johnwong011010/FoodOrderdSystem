using FoodOrdedSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace FoodOrdedSystem.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IFoodDbContext _context;
        public UnitOfWork(IFoodDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ExcuteInTransactionAsync(Func<Task> action,IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,CancellationToken ct = default)
        {
            await using var transaction = await _context.BeginTranscationAsync(isolationLevel);
            try
            {
                await action();
                await _context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }

        public async Task<T> ExcuteInTransactionAsync<T>(Func<Task<T>> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default)
        {
            await using var transaction = await _context.BeginTranscationAsync(isolationLevel);
            try
            {
                var result = await action();
                await _context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }
    }
}
