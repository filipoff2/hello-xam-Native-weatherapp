using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services.Interfaces
{
    public interface IUrlService
    {
        string GetCityUrl(bool withMetricSystem, string name);

        string GetLongTermWeatherUrl(bool withMetricSystem, string name, int daysCount);

        string GetHourlyWeatherUrl(bool withMetricSystem, string name, int forHours);
    }
}
