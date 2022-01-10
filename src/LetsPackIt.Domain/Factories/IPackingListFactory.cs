using LetsPackIt.Domain.Consts;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList Create(PackingListId id, PackingListName name, Localization localization);

        PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature , Localization localization);
    }
}