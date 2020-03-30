using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UIKit;
using WeatherApp.iOS.Utility;
using WeatherApp.iOS.Views;
using WeatherApp.Models;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.iOS
{
    public class AppNavigator : INavigationService
    {
        #region Boilerplate

        private readonly IDialogService _dialogService;
        private readonly SimpleIoc _ioc;

        private UINavigationController _root;
        private Dictionary<string, Route> _routes = new Dictionary<string, Route>();

        public AppNavigator(SimpleIoc ioc)
        {
            _dialogService = ioc.GetInstance<IDialogService>();
            _ioc = ioc;
        }

        private delegate void Route(object parameter);

        public string CurrentPageKey => null;

        private Route this[string key]
        {
            get => _routes[key];
            set => _routes[key] = value;
        }

        public void GoBack()
        {
            _root.PopViewController(true);
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            _routes[pageKey](parameter);
        }

        public UIWindow Setup()
        {
            _root = new UINavigationController();
            var window = new UIWindow();
            window.RootViewController = _root;

            Register();

            ShowInitial();

            window.MakeKeyAndVisible();
            return window;
        }

        public T Instantiate<T>() where T: UIViewController
        {
            var storybard = UIStoryboard.FromName(typeof(T).Name, null);
            return storybard.InstantiateInitialViewController() as T;
        }

        #endregion

        private void Register()
        {
            _ioc.Register<CitySelectViewModel>();
            this[CitySelectViewModel.ShowCityDetails] = (obj) => ShowCityDetails((CityLong)obj);

            _ioc.Register<CityDetailsViewModel>();
        }

        private void ShowInitial()
        {
            ShowCitySelect();
        }

        private void ShowCitySelect()
        {
            var vc = Instantiate<CitySelectViewController>();
            vc.ViewModel = _ioc.GetInstance<CitySelectViewModel>();
            _root.PushViewController(vc, true);
        }

        private void ShowCityDetails(CityLong city)
        {


            var vc = Instantiate<CityDetailsViewController>();
            vc.ViewModel = _ioc.GetInstance<CityDetailsViewModel>();
            vc.ViewModel.CityLongModel = city;

            _root.Delegate = new CustomTransitionCoordinator();
            _root.PushViewController(vc, true);
        }
    }
}
