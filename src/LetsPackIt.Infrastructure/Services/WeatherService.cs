using System;
using System.Threading.Tasks;
using LetsPackIt.Application.DTO.External;
using LetsPackIt.Application.Services;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}