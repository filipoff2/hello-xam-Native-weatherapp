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

        public const string ApiKey = "f5dd1350e64f758199c1cca5f98b2ed8";
        //private const string ApiKey = "9322eba14d4665ad66b06b489df48ecb";

        public const int Days = 14;
        public const int WeatherHours= 6;

    }
}
