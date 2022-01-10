using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class InvalidTemperatureException : LetsPackItException
    {
        public double Temp { get; }

        public InvalidTemperatureException(double temp) : base($"Value {temp} is invalid temperature")
        {
            Temp = temp;
        }
    }
}