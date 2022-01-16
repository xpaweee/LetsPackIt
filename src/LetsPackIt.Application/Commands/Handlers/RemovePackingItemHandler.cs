using System.Threading.Tasks;
using LetsPackIt.Application.Exceptions;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands.Handlers
{
    internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemovePackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.RemoveItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}