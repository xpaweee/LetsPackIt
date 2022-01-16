using System;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name) : ICommand;
}