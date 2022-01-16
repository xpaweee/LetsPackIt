using System;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands
{
    public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : ICommand;
}