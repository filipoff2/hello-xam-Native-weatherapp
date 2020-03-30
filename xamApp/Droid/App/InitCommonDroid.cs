using GalaSoft.MvvmLight.Views;

using WeatherApp.Droid.Navigation;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Droid
{
    public class InitCommonDroid : InitCommon
    {
        protected override void RegisterPlatformServices()
        {
            this.Ioc.Register<IDialogService, DialogServiceDroid>();
            this.Ioc.Register<IViewPresenter, ViewPresenter>();
        }

        protected override void Prepare()
        {
        }
    }
}