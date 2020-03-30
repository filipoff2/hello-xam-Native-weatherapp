using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Common;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class UrlService : IUrlService
    {
        public string GetCityUrl(bool withMetricSystem, string name)
        {
            var path = $"weather?q={name}&units={GetUnitsParameterValue(withMetricSystem)}";
            return GetUrl(path);
        }

        private static string GetUrl(string path)
        {
            return $"{ApiConstants.BasePath}{path}&appid={ApiConstants.ApiKey}";
        }

        public string GetLongTermWeatherUrl(bool withMetricSystem, string name, int daysCount)
        {
            var path = $"forecast/daily?q={name}&units={GetUnitsParameterValue(withMetricSystem)}&cnt={daysCount}";
            return GetUrl(path);
        }

        public string GetHourlyWeatherUrl(bool withMetricSystem, string name, int forHours)
        {
            int cnt = (int)Math.Ceiling((double)forHours / 3);
            cnt = Math.Max(1, cnt);

            var path = $"forecast?q={name}&units={GetUnitsParameterValue(withMetricSystem)}&cnt={cnt}";
            return GetUrl(path);
        }

        private string GetUnitsParameterValue(bool metric)
        {
            return metric ? ApiConstants.MetricUnitsParameterValue : ApiConstants.ImperialUnitsParameterValue;
        }
    }
}