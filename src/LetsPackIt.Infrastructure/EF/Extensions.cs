using LetsPackIt.Application.Services;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Infrastructure.EF.Contexts;
using LetsPackIt.Infrastructure.EF.Options;
using LetsPackIt.Infrastructure.Repositories;
using LetsPackIt.Infrastructure.Services;
using LetsPackIt.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsPackIt.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IPackingListRepository, PackingListRepository>();
            serviceCollection.AddScoped<IPackingListReadService, PackingListReadService>();
            
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            serviceCollection.AddDbContext<ReadDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));
            
            serviceCollection.AddDbContext<WriteDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));
            
            return serviceCollection;
        }
    }
}