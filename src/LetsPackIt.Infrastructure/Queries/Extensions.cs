using System.Linq;
using LetsPackIt.Application.DTO;
using LetsPackIt.Infrastructure.EF.Models;

namespace LetsPackIt.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDto
                {
                    City = readModel.Localization?.City,
                    Country = readModel.Localization?.Country
                },
                Items = readModel.Items.Select(x => new PackingItemDto
                {
                    Name = x.Name,
                    IsPacked = x.IsPacked,
                    Quantity = x.Quantity
                })
            };
    }
}