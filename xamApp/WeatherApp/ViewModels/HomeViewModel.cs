using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PCLStorage;
using WeatherApp.Models;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public const string ShowCityDetails = "CitySelectViewModel.ShowCityDetails";

        private readonly IWeatherApi _api;
        
        bool _isLoading;
        string _searchText = "";

        public HomeViewModel(IRoutingService navigationService, IDialogService dialogService, IWeatherApi api) 
            : base(dialogService, navigationService)
        {
            this._api = api;
            SearchCommand = new RelayCommand(async () => await PerformSearch(), CanSearch);
            
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            private set
            {
                Set(ref _isLoading, value);
            }
        }

        public RelayCommand SearchCommand { get; private set; }

        public string SearchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                Set(ref _searchText, value);
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        bool CanSearch()
        {
             return SearchText.Length > 3;
        }

        async Task PerformSearch()
        {
            try
            {
                IsLoading = true;
                var city = await _api.GetCity(SearchText);
                NavigateTo(ShowCityDetails, city);
            }
            catch(Exception ee)
            {
                var e = ee.Message;
                await ShowErrorDialog();
            }
            finally
            {
                IsLoading = false;
            }
        }


    }
}
