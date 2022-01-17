using System.Collections.Generic;
using LetsPackIt.Application.DTO;
using LetsPackIt.Shared.Abstractions.Queries;

namespace LetsPackIt.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
        
    }
}