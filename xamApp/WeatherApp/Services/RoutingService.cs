using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{

    public class RoutingService : IRoutingService
    {
        public const string Initial = "RoutingService.Initial";

        public delegate void Route(NavigationRequest request);

        private Dictionary<string, Route> _routes = new Dictionary<string, Route>();

        public void NavigateTo(string key, object parameter, ViewModelBase sender)
        {
            var request = new NavigationRequest
            {
                Key = key,
                Sender = sender,
                Parameter = parameter
            };
            _routes[key](request);
        }

        public Route this[string key]
        {
            get => _routes[key];
            set => _routes[key] = value;
        }

        public void BeginInitial()
        {
            NavigateTo(Initial, null, null);
        }

    }
}
