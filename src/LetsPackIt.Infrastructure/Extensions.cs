using LetsPackIt.Application.Services;
using LetsPackIt.Infrastructure.EF;
using LetsPackIt.Infrastructure.Logging;
using LetsPackIt.Infrastructure.Services;
using LetsPackIt.Shared;
using LetsPackIt.Shared.Abstractions.Commands;
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
            serviceCollection.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            serviceCollection.AddSingleton<IWeatherService, WeatherService>();
                
            return serviceCollection;
        }
    }
}