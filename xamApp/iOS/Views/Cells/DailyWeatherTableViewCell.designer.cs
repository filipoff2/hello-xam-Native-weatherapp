// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherApp.iOS.Views
{
    [Register ("DailyWeatherTableViewCell")]
    partial class DailyWeatherTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DailyTemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DayLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NightTemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView WeatherIconImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DailyTemperatureLabel != null) {
                DailyTemperatureLabel.Dispose ();
                DailyTemperatureLabel = null;
            }

            if (DayLabel != null) {
                DayLabel.Dispose ();
                DayLabel = null;
            }

            if (NightTemperatureLabel != null) {
                NightTemperatureLabel.Dispose ();
                NightTemperatureLabel = null;
            }

            if (WeatherIconImageView != null) {
                WeatherIconImageView.Dispose ();
                WeatherIconImageView = null;
            }
        }
    }
}