using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : LetsPackItException
    {
        public EmptyPackingListItemNameException() : base("Packing item name cannot be empty. ")
        {
        }
    }
}