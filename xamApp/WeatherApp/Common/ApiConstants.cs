using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Common
{
    public class ApiConstants
    {
        public const string MetricUnitsParameterValue = "metric";
        public const string ImperialUnitsParameterValue = "imperial";

        public const string BasePath = "https://api.openweathermap.org/data/2.5/";
        public const string iconPath = "https://openweathermap.org/img/w/";

        public const string ApiKey = "xxx_your_code";
        
        public const int Days = 14;
        public const int WeatherHours= 6;

    }
}
