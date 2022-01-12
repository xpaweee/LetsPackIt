using System.Threading.Tasks;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId id);
        Task AddAsync(PackingList packingList);
        Task UpdateAsync (PackingList packingList);
        Task DeleteAsync (PackingList packingList);
    }
}