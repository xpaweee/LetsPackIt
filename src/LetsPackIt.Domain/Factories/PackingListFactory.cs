using LetsPackIt.Domain.Consts;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        {
            throw new System.NotImplementedException();
        }

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature, Localization localization)
        {
            throw new System.NotImplementedException();
        }
    }
}