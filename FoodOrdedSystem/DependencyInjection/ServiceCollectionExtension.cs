using FoodOrdedSystem.Application.DependencyInjection;

namespace FoodOrdedSystem.API.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationService(configuration);
            return services;
        }
    }
}
