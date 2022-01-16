using LetsPackIt.Domain.Factories;
using LetsPackIt.Domain.Policies;
using LetsPackIt.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace LetsPackIt.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCommands();
            serviceCollection.AddSingleton<IPackingListFactory, PackingListFactory>();
            
            serviceCollection.Scan(x => x.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(y => y.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
                
            return serviceCollection;
        }
    }
}