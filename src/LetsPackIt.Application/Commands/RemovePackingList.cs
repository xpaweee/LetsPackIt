using System;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands
{
    public record RemovePackingList(Guid Id) : ICommand;
}