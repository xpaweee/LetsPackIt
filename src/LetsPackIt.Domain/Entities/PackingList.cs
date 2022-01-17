using System;
using System.Collections.Generic;
using System.Linq;
using LetsPackIt.Domain.Events;
using LetsPackIt.Domain.Exceptions;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Shared.Abstractions.Domain;

namespace LetsPackIt.Domain.Entities
{
    public class PackingList : AggregateRoot<PackingListId>
    {
        public PackingListId Id { get; private set; }
        private PackingListName _name;
        private Localization _localization;
        private readonly LinkedList<PackingItem> _packingItems = new();

        // internal PackingList(Guid id,PackingListName name, Localization localization, LinkedList<PackingItem> packingItems)
        //     :this(id,name,localization)
        // {
        //     AddItems(packingItems);
        // }
        
        // EF
        private PackingList()
        {
        }

        internal PackingList(Guid id,PackingListName name, Localization localization )
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            if (_packingItems.Any(x => x.Name == item.Name))
                throw new PackingItemAlreadyExistsException(_name,item.Name);

            _packingItems.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };

            _packingItems.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this, item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _packingItems.Remove(item);

            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _packingItems.SingleOrDefault(x => x.Name == itemName);
            if (item is null)
                throw new PackingItemNotFoundException(itemName);
            
            return item;
        }
            
    }
}