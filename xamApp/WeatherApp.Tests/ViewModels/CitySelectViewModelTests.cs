using System;
using System.Net.Http;
using GalaSoft.MvvmLight.Views;
using Moq;
using NUnit.Framework;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Tests.ViewModels
{
    //TODO add more test that use all dependencies

    [TestFixture]
    public class CitySelectViewModelTests
    {
        class Builder
        {
            public MockKeyValueStorageService Storage = new MockKeyValueStorageService();
            public MockRoutingService Navigation = new MockRoutingService();
            public MockDialogService Dialogs = new MockDialogService();
            public Mock<IWeatherApi> Api = new Mock<IWeatherApi>();
            public MockMeasureSystem measureSystem = new MockMeasureSystem();

            public CityLong City = new CityLong { Name = "London" };

            public bool NetworkEnabled = true;
            public string StoredCityName = null;

            public CitySelectViewModel Build()
            {
                if (NetworkEnabled)
                {
                    Api.Setup(x => x.GetCity(true, "London")).ReturnsAsync(City);
                } else 
                {
                    Api.Setup(x => x.GetCity(true, "London")).Throws(new NotSupportedException());
                }

                var preferences = new UserPreferencesService(Storage);

                return new CitySelectViewModel(Navigation, Dialogs, Api.Object, preferences, measureSystem);
            }
        }
        
        [Test]
        public void Should_Load_Empty_Storage()
        {
            var builder = new Builder();

            var vm = builder.Build();

            Assert.AreEqual("", vm.SearchText);
        }

        [Test]
        public void Should_Load_Stored_City()
        {
            var builder = new Builder();
            builder.Storage.Content[UserPreferencesService.CityNameStorageKey] = "xyz";

            var vm = builder.Build();

            Assert.AreEqual("xyz", vm.SearchText);
        }

        [Test]
        public void Should_Navigate_After_Search()
        {
            var builder = new Builder();

            var vm = builder.Build();
            vm.SearchText = "London";
            vm.SearchCommand.Execute(null);

            builder.Navigation.Check(CitySelectViewModel.ShowCityDetails, builder.City);
            builder.Dialogs.CheckNotAppeared();
        }

        [Test]
        public void Should_Show_Dialog_On_Error()
        {
            var builder = new Builder();
            builder.NetworkEnabled = false;

            var vm = builder.Build();
            vm.SearchText = "London";
            vm.SearchCommand.Execute(null);

            builder.Navigation.Check(null, null);
            builder.Dialogs.CheckAppeared();
        }
    }
}
