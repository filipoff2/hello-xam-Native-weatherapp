using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Common;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class WeatherApi : IWeatherApi
    {
        private readonly IHttpClient _client;
        private readonly IUrlService _urlService;

        public WeatherApi(IHttpClient client, IUrlService urlService)
        {
            _client = client;
            _urlService = urlService;
        }

        public async Task<CityLong> GetCity( string name)
        {
            var url = _urlService.GetCityUrl(true, name);
            return await _client.DoGetRequest<CityLong>(url);
        }

        public async Task<LongTermWeather> GetLongTermWeather( string name)
        {
            var url = _urlService.GetLongTermWeatherUrl( true,name, ApiConstants.Days);
            return await _client.DoGetRequest<LongTermWeather>(url);
        }

        public async Task<HourlyWeather> GetHourlyWeather( string name)
        {
            var url = _urlService.GetLongTermWeatherUrl(true, name, ApiConstants.WeatherHours);
            return await _client.DoGetRequest<HourlyWeather>(url);
        }
    }
}
