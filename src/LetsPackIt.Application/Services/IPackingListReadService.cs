using System.Threading.Tasks;

namespace LetsPackIt.Application.Services
{
    public interface IPackingListReadService
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}