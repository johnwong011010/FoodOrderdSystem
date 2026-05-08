using FoodOrdedSystem.Domain;
using FoodOrdedSystem.Domain.Repository;
using FoodOrdedSystem.Infrastructure;

namespace FoodOrdedSystem.Application
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FoodItemService(IFoodItemRepository foodItemRepository, IUnitOfWork unitOfWork)
        {
            _foodItemRepository = foodItemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<FoodItem?>> GetFoodItemListAsync()
        {
            return await _foodItemRepository.GetFoodItemListAsync();
        }
        public async Task<bool> AddFoodItemAsync(FoodItem item)
        {
            return await _unitOfWork.ExcuteInTransactionAsync(async () =>
            {
                var result = await _foodItemRepository.AddFoodItemAsync(item);
                await _unitOfWork.SaveChangesAsync();
                return result;
            });
        }
        public async Task<FoodItem?> UpdateFoodItemAsync(FoodItem item)
        {
            return await _unitOfWork.ExcuteInTransactionAsync(async () =>
            {
                var result = await _foodItemRepository.UpdateFoodItemAsync(item);
                await _unitOfWork.SaveChangesAsync();
                return result;
            });
        }
        public async Task DeleteFoodItem(int fid)
        {
            throw new NotImplementedException();
        }
    }
}