using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdedSystem.Domain;

namespace FoodOrdedSystem.Application
{
    public interface IFoodItemService
    {
        Task<List<FoodItem?>> GetFoodItemListAsync();
        Task<bool> AddFoodItemAsync(FoodItem item);
        Task<FoodItem?> UpdateFoodItemAsync(FoodItem item);
        Task DeleteFoodItem(int fid);
    }
}
