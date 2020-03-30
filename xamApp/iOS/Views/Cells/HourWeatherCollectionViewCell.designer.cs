// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherApp.iOS.Views.Cells
{
    [Register ("HourWeatherCollectionViewCell")]
    partial class HourWeatherCollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HourLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView IconImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TemperatureLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HourLabel != null) {
                HourLabel.Dispose ();
                HourLabel = null;
            }

            if (IconImageView != null) {
                IconImageView.Dispose ();
                IconImageView = null;
            }

            if (TemperatureLabel != null) {
                TemperatureLabel.Dispose ();
                TemperatureLabel = null;
            }
        }
    }
}