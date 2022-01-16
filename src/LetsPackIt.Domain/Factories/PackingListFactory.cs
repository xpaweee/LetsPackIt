using System.Collections.Generic;
using System.Linq;
using LetsPackIt.Domain.Consts;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.Policies;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
        {
            _policies = policies;   
        }

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new(id, name, localization);
            

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature, Localization localization)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolicies = _policies.Where(x => x.IsApplicable(data));

            var items = applicablePolicies.SelectMany(x => x.GenerateItems(data));
            var packingList = Create(id, name, localization);
            
            packingList.AddItems(items);

            return packingList;
        }
    }
}