using System.Threading.Tasks;
using LetsPackIt.Application.Exceptions;
using LetsPackIt.Application.Services;
using LetsPackIt.Domain.Factories;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Shared.Abstractions.Commands;

namespace LetsPackIt.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _packingListFactory;
        private readonly IPackingListReadService _packingListReadService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory packingListFactory, IPackingListReadService packingListReadService, IWeatherService weatherService)
        {
            _repository = repository;
            _packingListFactory = packingListFactory;
            _packingListReadService = packingListReadService;
            _weatherService = weatherService;
        }
        
        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;
            
            if (await _packingListReadService.ExistsByNameAsync(name))
                throw new PackingListAlreadyExistsException(command.Name);

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
                throw new MissingLocalizationWeatherException(localization);

            var packingList =
                _packingListFactory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

            await _repository.AddAsync(packingList);

        }
    }
}