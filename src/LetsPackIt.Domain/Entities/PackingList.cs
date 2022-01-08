using System;
using System.Collections.Generic;
using System.Linq;
using LetsPackIt.Domain.Exceptions;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Entities
{
    public class PackingList
    {
        public Guid Id { get; private set; }
        private PackingListName _name;
        private Localization _localization;
        private readonly LinkedList<PackingItem> _packingItems = new();

        internal PackingList(Guid id,PackingListName name, Localization localization, LinkedList<PackingItem> packingItems)
        {
            Id = id;
            _name = name;
            _localization = localization;
            _packingItems = packingItems;
        }

        public void AddItem(PackingItem item)
        {
            if (_packingItems.Any(x => x.Name == item.Name))
                throw new PackingItemAlreadyExistsException(_name,item.Name);

            _packingItems.AddLast(item);

        }
            
    }
}