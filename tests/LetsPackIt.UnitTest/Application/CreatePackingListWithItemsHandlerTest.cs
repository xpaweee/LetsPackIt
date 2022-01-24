using System;
using System.Threading.Tasks;
using LetsPackIt.Application.Commands;
using LetsPackIt.Application.Commands.Handlers;
using LetsPackIt.Application.DTO.External;
using LetsPackIt.Application.Exceptions;
using LetsPackIt.Application.Services;
using LetsPackIt.Domain.Consts;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.Factories;
using LetsPackIt.Domain.Repositories;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Shared.Abstractions.Commands;
using NSubstitute;
using Shouldly;
using Xunit;

namespace LetsPackIt.UnitTest.Application
{
    public class CreatePackingListWithItemsHandlerTest
    {
        #region Arrange

        private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTest()
        {
            
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();

            _commandHandler =
                new CreatePackingListWithItemsHandler(_repository, _factory, _readService, _weatherService);
        }


        #endregion
        
        Task Act(CreatePackingListWithItems command)
        {
            return _commandHandler.HandleAsync(command);
        }

        [Fact]
        public async Task HandleAsync_Throws_PackingListAlreadyExsitsException_When_List_With_Same_Name_Already_Exists()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, default);
            _readService.ExistsByNameAsync(command.Name).Returns(true);

            var exception = Record.ExceptionAsync(() => Act(command));
            await exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_Returned_From_Service()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MYLIST", 10, Gender.Female, new LocalizationWriteModel("Warsaw","Poland"));
            
            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));
            
            var exception = Record.ExceptionAsync(() => Act(command));
            await exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();
        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MYLIST", 10, Gender.Female, new LocalizationWriteModel("Warsaw","Poland"));
            
            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(12));
            _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
                Arg.Any<Temperature>(), Arg.Any<Localization>()).Returns(default(PackingList));

            var exception = await Record.ExceptionAsync(() => Act(command));
            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
        }
    }
}