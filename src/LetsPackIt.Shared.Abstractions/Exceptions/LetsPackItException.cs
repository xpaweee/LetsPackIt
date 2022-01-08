using System;

namespace LetsPackIt.Shared.Abstractions.Exceptions
{
    public abstract class LetsPackItException : Exception
    {
        protected LetsPackItException(string message) : base(message)
        {
            
        }
    }
}