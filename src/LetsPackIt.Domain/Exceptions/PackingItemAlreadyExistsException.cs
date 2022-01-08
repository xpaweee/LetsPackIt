using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class PackingItemAlreadyExistsException : LetsPackItException
    {
        public PackingItemAlreadyExistsException(string listName, string itemName) 
            : base($"Packing list: {listName} already defined item {itemName}")
        {
            
        }
    }
}