using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class InvalidTravelDaysException : LetsPackItException
    {
        private readonly ushort _days;

        public InvalidTravelDaysException(ushort days ) : base($"Value '{days} is invalid travel days")
        {
            _days = days;
        }
    }
}