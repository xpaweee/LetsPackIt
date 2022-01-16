using System.Threading.Tasks;
using LetsPackIt.Application.DTO.External;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(Localization localization);
    }
}