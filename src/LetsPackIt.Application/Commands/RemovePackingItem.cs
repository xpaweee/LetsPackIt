using System;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands
{
    public record RemovePackingItem(Guid PackingListId, string Name) : ICommand;
}