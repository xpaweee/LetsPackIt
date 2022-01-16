using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackingListAlreadyExistsException
    {
        public Localization Localization { get; }

        public MissingLocalizationWeatherException(Localization localization) : base($"Could't fetch weather data for localization {localization.Country} - {localization.City}")
        {
            Localization = localization;
        }
    }
}