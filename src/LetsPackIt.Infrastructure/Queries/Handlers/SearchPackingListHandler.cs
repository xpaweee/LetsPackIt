using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsPackIt.Application.DTO;
using LetsPackIt.Application.Queries;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Infrastructure.EF.Contexts;
using LetsPackIt.Infrastructure.EF.Models;
using LetsPackIt.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace LetsPackIt.Infrastructure.Queries.Handlers
{
    internal class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingList;
        private readonly PackingList test;

        public SearchPackingListHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }
        public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingList
                .Include(x => x.Items)
                .AsQueryable();
            if (query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(x =>
                    Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchPhrase}%"));
            }

                

            return await dbQuery
                .Select(x => x.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}