using System.Linq;
using System.Threading.Tasks;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LetsPackIt.Infrastructure.Repositories
{
    internal sealed class PackingListRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingLists;
        private readonly WriteDbContext _writeDbContext;

        public PackingListRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _packingLists = writeDbContext.PackingLists;
        }

        public Task<PackingList> GetAsync(PackingListId id)
            => _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

        public async Task AddAsync(PackingList packingList)
        {
            await _packingLists.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PackingList packingList)
        {
             _packingLists.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingLists.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}