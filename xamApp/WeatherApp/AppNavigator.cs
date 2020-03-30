using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using WeatherApp.Models;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.Utils;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Describes connections between ViewModels. 
    /// </summary>
    public class AppNavigator
    {
        private readonly IDialogService _dialogService;
        private readonly IViewPresenter _presenter;
        private readonly RoutingService _router;
        

        public AppNavigator(IDialogService dialogService, IViewPresenter presenter, RoutingService router)
        {
            _dialogService = dialogService;
            _presenter = presenter;
            _router = router;
        
        }

        public void Configure()
        {
            _router[RoutingService.Initial] = ShowCitySelect;
        }

        private void ShowCitySelect(NavigationRequest request)
        {
            // this line means that CitySelectViewModel can navigate only to ShowCityDetails
            _router[HomeViewModel.ShowCityDetails] = ShowCityDetails;

            var vm = SimpleIoc.Default.GetInstance<HomeViewModel>();
            _presenter.Show(vm, request);
        }

        private void ShowCityDetails(NavigationRequest request)
        {
            var vm = SimpleIoc.Default.GetInstance<DetailsViewModel>();
            vm.CityLongModel = (CityLong)request.Parameter;
            _presenter.Show(vm, request);
        }
    }
}
