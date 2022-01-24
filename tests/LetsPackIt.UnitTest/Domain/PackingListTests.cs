using System;
using System.Linq;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.Events;
using LetsPackIt.Domain.Exceptions;
using LetsPackIt.Domain.Factories;
using LetsPackIt.Domain.Policies;
using LetsPackIt.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace LetsPackIt.UnitTest.Domain
{
    public class PackingListTests
    {
        #region Arrange
        private readonly IPackingListFactory _packingListFactory;

        public PackingListTests()
        {
            _packingListFactory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
        }

        private PackingList GetPackingList()
        {
            var packingList =
                _packingListFactory.Create(Guid.NewGuid(), "MyList", Localization.Create("Warsaw, Poland"));
            packingList.ClearEvents();
            
            return packingList;
        }
        #endregion
        
        
        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_same_name()
        {
            //Arrange
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item 1",1));
            
            //Act
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1",1)));
            
            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
        }

        [Fact]
        public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
        {
            //Arrange
            var packingList = GetPackingList();
            
            //Act
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1",1)));
            
            //Assert
            exception.ShouldBeNull();
            packingList.Events.Count().ShouldBe(1);

            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;
            @event.ShouldNotBeNull();
        }
     

      
    }
}