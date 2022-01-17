using LetsPackIt.Infrastructure.EF;
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
                
            return serviceCollection;
        }
    }
}