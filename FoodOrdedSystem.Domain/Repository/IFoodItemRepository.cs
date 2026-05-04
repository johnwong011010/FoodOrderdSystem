using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdedSystem.Infrastructure;
using FoodOrdedSystem.Infrastructure.Repository;

namespace FoodOrdedSystem.Domain.Repository
{
    public interface IFoodItemRepository : IRepository<FoodItem>
    {
        Task<List<FoodItem?>> GetFoodItemListAsync();
        Task<bool> AddFoodItemAsync(FoodItem item);
        Task<FoodItem?> UpdateFoodItemAsync(FoodItem item);
        Task DeleteFoodItem(int fid);
    }
}
