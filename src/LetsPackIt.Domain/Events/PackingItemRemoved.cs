using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Shared.Abstractions.Domain;

namespace LetsPackIt.Domain.Events
{
    public record PackingItemRemoved(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;

}