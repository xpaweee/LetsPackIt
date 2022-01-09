using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Domain.Exceptions
{
    public class PackingItemNotFoundException : LetsPackItException
    {
        private readonly string _itemName;

        public PackingItemNotFoundException(string itemName ) : base($"Packing item {itemName} was not found.")
        {
            _itemName = itemName;
        }
    }
}