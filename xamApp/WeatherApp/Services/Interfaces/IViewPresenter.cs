using GalaSoft.MvvmLight;

namespace WeatherApp.Services.Interfaces
{
    public interface IViewPresenter
    {
        void Show(ViewModelBase viewModel, NavigationRequest request);
    }
}
