using System;
using LetsPackIt.Shared.Abstractions.Commands;
using LetsPackIt.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace LetsPackIt.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            
            return services;
        }
    }
}