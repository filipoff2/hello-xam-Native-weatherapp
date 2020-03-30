using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected IDialogService DialogService { get; }
        protected IRoutingService RoutingService { get; }

        public BaseViewModel(IDialogService dialogService, IRoutingService routingService)
        {
            DialogService = dialogService;
            RoutingService = routingService;
        }

        protected virtual Task ShowErrorDialog()
        {
            return DialogService.ShowError(LocalizedStrings.ErrorDialogMessage, LocalizedStrings.ErrorDialogTitle, LocalizedStrings.OK, null);
        }

        protected void NavigateTo(string key, object parameter)
        {
            RoutingService.NavigateTo(key, parameter, this);
        }
    }
}
