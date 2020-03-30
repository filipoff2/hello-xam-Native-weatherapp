using System.Linq;
using Foundation;
using GalaSoft.MvvmLight.Views;
using UIKit;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.iOS
{
    class InitCommoniOS : InitCommon
    {
        protected override void RegisterPlatformServices()
        {
            Ioc.Register<IDialogService, DialogService>();
            Ioc.Register<ViewPresenter>();
            RegisterExisting<IViewPresenter, ViewPresenter>();
        }

        public UIWindow Window { get; private set; }

        protected override void Prepare()
        {
            Window = Ioc.GetInstance<ViewPresenter>().Setup();
        }

    }
}