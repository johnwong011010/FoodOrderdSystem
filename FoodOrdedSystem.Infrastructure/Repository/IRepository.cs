using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdedSystem.Infrastructure.Repository
{
    public interface IRepository<TPrimaryKey,TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query { get; }
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(TPrimaryKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(TPrimaryKey id);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRepository<TEntity> : IRepository<int, TEntity> where TEntity : class, IEntity
    {
        
    }
}
