using System.Collections.Generic;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Policies.Gender
{
    internal class MaleGenderPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new PackingItem("Laptop", 1),
                new PackingItem("Beer", 10),
                new PackingItem("Book", 2),
            };
    }
}