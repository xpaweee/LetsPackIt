using System;
using LetsPackIt.Application.DTO;
using LetsPackIt.Shared.Abstractions.Queries;

namespace LetsPackIt.Application.Queries
{
    public class GetPackingList :  IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}