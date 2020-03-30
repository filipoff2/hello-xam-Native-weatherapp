using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    //public interface IViewModelProvider
    //{
    //    T GetViewModel<T>() where T : ViewModelBase;
    //}

    /// <summary>
    /// Initializes services.
    /// </summary>
    public abstract class InitCommon
    {
        protected virtual SimpleIoc Ioc => SimpleIoc.Default;

        protected virtual void RegisterCommonServices()
        {
            Ioc.Register<IHttpClient, HttpClientBase>();
            Ioc.Register<IUrlService, UrlService>();
            Ioc.Register<IWeatherApi, WeatherApi>();

            Ioc.Register<RoutingService>();
            RegisterExisting<IRoutingService, RoutingService>();

            
            Ioc.Register<AppNavigator>();

            ServiceLocator.SetLocatorProvider(() => Ioc);
        }

        protected abstract void RegisterPlatformServices();

        protected virtual void RegisterViewModels()
        {
            Ioc.Register<HomeViewModel>();
            Ioc.Register<DetailsViewModel>();
        }

        protected void RegisterExisting<T1, T2>() where T2 : T1 where T1 : class
        {
            Ioc.Register<T1>(() => Ioc.GetInstance<T2>());
        }

        public void Register()
        {
            RegisterCommonServices();
            RegisterPlatformServices();
            RegisterViewModels();
        }

        protected abstract void Prepare();

        public void Run()
        {
            Prepare();
            var routing = Ioc.GetInstance<RoutingService>();
            var navigator = Ioc.GetInstance<AppNavigator>();

            navigator.Configure();
            routing.BeginInitial();
        }
    }
}
