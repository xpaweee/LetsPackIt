using System.Collections.Generic;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<PackingItem> GenerateItems(PolicyData data);
    }
}