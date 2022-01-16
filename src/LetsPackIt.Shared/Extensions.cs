using System;
using System.Reflection;
using LetsPackIt.Shared.Abstractions.Commands;
using LetsPackIt.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace LetsPackIt.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.Scan(x => x.FromAssemblies(assembly)
                .AddClasses(y => y.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}