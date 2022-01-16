using System.Threading.Tasks;
using LetsPackIt.Application.Exceptions;
using LetsPackIt.Application.Services;
using LetsPackIt.Domain.Factories;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _packingListFactory;
        private readonly IPackingListReadService _packingListReadService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory packingListFactory, IPackingListReadService packingListReadService)
        {
            _repository = repository;
            _packingListFactory = packingListFactory;
            _packingListReadService = packingListReadService;   
        }
        
        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localization) = command;
            
            if (await _packingListReadService.ExistsByNameAsync(name))
                throw new PackingListAlreadyExistsException(command.Name);
            
        }
    }
}