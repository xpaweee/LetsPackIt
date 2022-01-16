using System;
using System.Reflection;
using LetsPackIt.Shared.Abstractions.Commands;
using LetsPackIt.Shared.Abstractions.Queries;
using LetsPackIt.Shared.Commands;
using LetsPackIt.Shared.Queries;
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

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            
            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(x => x.FromAssemblies(assembly)
                .AddClasses(y => y.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}