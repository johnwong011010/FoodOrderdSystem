using FoodOrdedSystem.Infrastructure;

namespace FoodOrdedSystem.Domain
{
    /// <summary>
    /// Define a food item,you can define yourself as you like.
    /// </summary>
    public class FoodItem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Sales { get; set; }
    }
}
