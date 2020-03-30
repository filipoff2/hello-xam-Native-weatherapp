//based on the file NavigationService.cs

using System;
using System.Collections.Generic;
using Android.Content;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Plugin.CurrentActivity;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Droid.Navigation
{
    /// <summary>
    ///     Xamarin Android implementation of <see cref="INavigationService" />.
    ///     This implementation can be used in Xamarin Android applications (not Xamarin Forms).
    /// </summary>
    /// <remarks>
    ///     For this navigation service to work properly, your Activities
    ///     should derive from the <see cref="ActivityBase" /> class.
    /// </remarks>
    ////[ClassInfo(typeof(INavigationService))]
    public class AppNavigatorService : INavigationService
    {
        #region Boilerplate

        private readonly SimpleIoc _ioc;

        public AppNavigatorService(SimpleIoc ioc)
        {
            _ioc = ioc;
        }

        public INavigationView CurrentView => CrossCurrentActivity.Current.Activity as INavigationView;

        /// <summary>
        ///     The key that is returned by the <see cref="CurrentPageKey" /> property
        ///     when the current Activiy is the root activity.
        /// </summary>
        public const string RootPageKey = "-- ROOT --";

        private const string ParameterKeyName = "ParameterKey";

        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<string, Route> _routes = new Dictionary<string, Route>();


        private delegate void Route(object parameter);


        private Route this[string key]
        {
            get => _routes[key];
            set => _routes[key] = value;
        }

        /// <summary>
        ///     The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey => CurrentView.Helper.ActivityKey ?? RootPageKey;

        /// <summary>
        ///     Adds a key/page pair to the navigation service.
        /// </summary>
        /// <remarks>
        ///     For this navigation service to work properly, your Activities
        ///     should derive from the <see cref="ActivityBase" /> class.
        /// </remarks>
        /// <param name="key">
        ///     The key that will be used later
        ///     in the <see cref="NavigateTo(string)" /> or <see cref="NavigateTo(string, object)" /> methods.
        /// </param>
        /// <param name="activityType">The type of the activity (page) corresponding to the key.</param>
        public void Configure(string key, Type activityType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                    _pagesByKey[key] = activityType;
                else
                    _pagesByKey.Add(key, activityType);
            }
        }

        /// <summary>
        ///     If possible, discards the current page and displays the previous page
        ///     on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            CurrentView.Helper.GoBack();
        }


        /// <summary>
        ///     Displays a new page corresponding to the given key.
        ///     Make sure to call the <see cref="Configure" />
        ///     method first.
        /// </summary>
        /// <param name="pageKey">
        ///     The key corresponding to the page
        ///     that should be displayed.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     When this method is called for
        ///     a key that has not been configured earlier.
        /// </exception>
        public void NavigateTo(string pageKey)
        {
           NavigateTo(pageKey, null);
        }

        /// <summary>
        ///     Displays a new page corresponding to the given key,
        ///     and passes a parameter to the new page.
        ///     Make sure to call the <see cref="Configure" />
        ///     method first.
        /// </summary>
        /// <param name="pageKey">
        ///     The key corresponding to the page
        ///     that should be displayed.
        /// </param>
        /// <param name="parameter">
        ///     The parameter that should be passed
        ///     to the new page.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     When this method is called for
        ///     a key that has not been configured earlier.
        /// </exception>
        public void NavigateTo(string pageKey, object parameter)
        {

            if (CurrentView.Helper.CurrentActivity == null)
                throw new InvalidOperationException("No CurrentActivity found");

            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");

                _routes[pageKey](parameter);


                var intent = new Intent(CurrentView.Helper.CurrentActivity, _pagesByKey[pageKey]);

                CurrentView.Helper.CurrentActivity.StartActivity(intent);
                CurrentView.Helper.NextPageKey = pageKey;
            }
        }

        #endregion

        public void Setup()
        {
            Register();
        }

        public void Register()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            _ioc.Register<CitySelectViewModel>();
            _ioc.Register<CityDetailsViewModel>();
            this[CitySelectViewModel.ShowCityDetails] = obj => SetCityDetails((CityLong) obj);
        }

        private void SetCityDetails(CityLong city)
        {
            var vm = ServiceLocator.Current.GetInstance<CityDetailsViewModel>();
            vm.CityLongModel = city;
        }
    }
}