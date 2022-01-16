using System;
using LetsPackIt.Domain.Consts;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, LocalizationWriteModel Localization
        ) : ICommand;

    public record LocalizationWriteModel(string City, string Country);

}