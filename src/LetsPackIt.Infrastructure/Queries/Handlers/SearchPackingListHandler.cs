using System.Collections.Generic;
using System.Threading.Tasks;
using LetsPackIt.Application.DTO;
using LetsPackIt.Application.Queries;
using LetsPackIt.Shared.Abstractions.Queries;

namespace LetsPackIt.Infrastructure.Queries.Handlers
{
    public class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            return null;
        }
    }
}