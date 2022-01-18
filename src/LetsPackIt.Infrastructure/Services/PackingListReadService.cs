using System.Threading.Tasks;
using LetsPackIt.Application.Services;
using LetsPackIt.Infrastructure.EF.Contexts;
using LetsPackIt.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsPackIt.Infrastructure.Services
{
    internal sealed class PackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public PackingListReadService(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public Task<bool> ExistsByNameAsync(string name)
            => _packingList.AnyAsync(x => x.Name == name);
    }
}