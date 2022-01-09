using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class EmptyPackingListIdException : LetsPackItException
    {
        public EmptyPackingListIdException() : base("Packing list id cannot be empty.")
        {
        }
    }
}