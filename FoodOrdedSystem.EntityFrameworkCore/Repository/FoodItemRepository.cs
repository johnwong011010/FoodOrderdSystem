using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdedSystem.Infrastructure;
using FoodOrdedSystem.Domain;
using FoodOrdedSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using FoodOrdedSystem.Domain.Repository;

namespace FoodOrdedSystem.EntityFrameworkCore.Repository
{
    public class FoodItemRepository : BaseRepository<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(IFoodDbContext context) : base(context)
        {
        }
        public async Task<List<FoodItem?>> GetFoodItemListAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<bool> AddFoodItemAsync(FoodItem item)
        {
            await AddAsync(item);
            return true;
        }
        public async Task<FoodItem?> UpdateFoodItemAsync(FoodItem item)
        {
            return await UpdateAsync(item);
        }
        public async Task DeleteFoodItem(int fid)
        {
            await DeleteByIdAsync(fid);
        }
    }
}
