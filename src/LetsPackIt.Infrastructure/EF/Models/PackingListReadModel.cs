using System;
using System.Collections;
using System.Collections.Generic;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Infrastructure.EF.Models
{
    internal class PackingListReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public Localization Localization { get; set; }
        public ICollection<PackingItemReadModel> Items { get; set; }
    }
}