using Microsoft.Extensions.Configuration;

namespace LetsPackIt.Shared.Options
{
    public static class Extensions
    {
        public static TOption GetOptions<TOption>(this IConfiguration configuration, string sectionName) where TOption : new()
        {
            var options = new TOption();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }
    }
}