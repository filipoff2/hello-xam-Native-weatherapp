using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherApi
    {
        Task<CityLong> GetCity(string name);
        Task<LongTermWeather> GetLongTermWeather(string name);
        Task<HourlyWeather> GetHourlyWeather(string name);
    }
}