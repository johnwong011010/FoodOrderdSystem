using FoodOrdedSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Serilog;

namespace FoodOrdedSystem.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IFoodDbContext _context;
        private readonly ILogger _logger;
        public UnitOfWork(IFoodDbContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.Information("Transaction started with isolation level {IsolationLevel}", isolationLevel);
                await action();
                await _context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
                _logger.Information("Transaction committed successfully");
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                _logger.Information("Transaction rolled back due to an error");
                throw;
            }
        }

        public async Task<T> ExcuteInTransactionAsync<T>(Func<Task<T>> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default)
        {
            await using var transaction = await _context.BeginTranscationAsync(isolationLevel);
            try
            {
                _logger.Information("Transaction started with isolation level {IsolationLevel}", isolationLevel);
                var result = await action();
                await _context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
                _logger.Information("Transaction committed successfully");
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                _logger.Information("Transaction rolled back due to an error");
                throw;
            }
        }
    }
}
