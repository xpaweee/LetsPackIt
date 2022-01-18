using LetsPackIt.Application.Services;
using LetsPackIt.Infrastructure.EF;
using LetsPackIt.Infrastructure.Services;
using LetsPackIt.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsPackIt.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddPostgres(configuration);
            serviceCollection.AddQueries();

            serviceCollection.AddSingleton<IWeatherService, WeatherService>();
                
            return serviceCollection;
        }
    }
}