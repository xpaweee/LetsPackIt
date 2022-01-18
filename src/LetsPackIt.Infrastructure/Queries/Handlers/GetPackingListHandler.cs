using System.Linq;
using System.Threading.Tasks;
using LetsPackIt.Application.DTO;
using LetsPackIt.Application.Queries;
using LetsPackIt.Infrastructure.EF.Contexts;
using LetsPackIt.Infrastructure.EF.Models;
using LetsPackIt.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace LetsPackIt.Infrastructure.Queries.Handlers
{
    internal class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public GetPackingListHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public Task<PackingListDto> HandleAsync(GetPackingList query)
            => _packingList.Include(x => x.Items)
                .Where(x => x.Id == query.Id)
                .Select(x => x.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();

    }
}