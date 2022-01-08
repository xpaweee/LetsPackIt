using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class EmptyPackingListNameException : LetsPackItException
    {
        public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
        {
        }
    }
}