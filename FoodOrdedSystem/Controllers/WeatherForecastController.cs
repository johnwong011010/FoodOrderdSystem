using FoodOrdedSystem.Application;
using FoodOrdedSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdedSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IFoodItemService _foodItemService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFoodItemService foodItemService)
        {
            _logger = logger;
            _foodItemService = foodItemService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("/FoodItem")]
        [ProducesResponseType(typeof(FoodItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<FoodItem>?> GetAllFoodItem(int? page,int? pageSize)
        {
            var request = await _foodItemService.GetFoodItemListAsync();
            return request;
        }
    }
}
