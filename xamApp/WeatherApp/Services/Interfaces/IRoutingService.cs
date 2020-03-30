using GalaSoft.MvvmLight;

namespace WeatherApp.Services.Interfaces
{
    public interface IRoutingService
    {
        void NavigateTo(string key, object parameter, ViewModelBase sender);
    }
}
