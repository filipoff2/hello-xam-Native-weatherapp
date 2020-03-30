using System;
using System.Diagnostics;
using System.Text;
using WeatherApp.Common;

namespace WeatherApp.Utils
{
    public class Logger
    {
        private static string separator = " - ";

        enum LogLayer
        {
            ERROR,
            WARNING,
            INFO
        }

		public static void LogError(string message)
		{
            Debug.WriteLine(CreateString(LogLayer.ERROR, message));
		}

		public static void LogWarning(string message)
		{
            Debug.WriteLine(CreateString(LogLayer.WARNING, message));
		}

        public static void Log(string message)
        {
            Debug.WriteLine(CreateString(LogLayer.INFO, message));
        }

        private static string CreateString(LogLayer logLayer, string message) 
        {
			var stringBuilder = new StringBuilder();
			stringBuilder.Append(logLayer.ToString());
			stringBuilder.Append(separator);
            stringBuilder.Append(message);

            return stringBuilder.ToString();
        }
    }
}
