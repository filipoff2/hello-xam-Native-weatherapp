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
    [Register ("DetailsPageController")]
    partial class DetailsPageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WeatherApp.iOS.ActivityIndicatorView ActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BottomSeparatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CurrentTemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CurrentWeatherIconView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DailyWeatherTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView HourlyWeatherCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TodayDayNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TodayMaxTemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TodayMinTemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopSeparatorView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (BottomSeparatorView != null) {
                BottomSeparatorView.Dispose ();
                BottomSeparatorView = null;
            }

            if (CityName != null) {
                CityName.Dispose ();
                CityName = null;
            }

            if (CurrentTemperatureLabel != null) {
                CurrentTemperatureLabel.Dispose ();
                CurrentTemperatureLabel = null;
            }

            if (CurrentWeatherIconView != null) {
                CurrentWeatherIconView.Dispose ();
                CurrentWeatherIconView = null;
            }

            if (DailyWeatherTableView != null) {
                DailyWeatherTableView.Dispose ();
                DailyWeatherTableView = null;
            }

            if (HourlyWeatherCollectionView != null) {
                HourlyWeatherCollectionView.Dispose ();
                HourlyWeatherCollectionView = null;
            }

            if (TodayDayNameLabel != null) {
                TodayDayNameLabel.Dispose ();
                TodayDayNameLabel = null;
            }

            if (TodayMaxTemperatureLabel != null) {
                TodayMaxTemperatureLabel.Dispose ();
                TodayMaxTemperatureLabel = null;
            }

            if (TodayMinTemperatureLabel != null) {
                TodayMinTemperatureLabel.Dispose ();
                TodayMinTemperatureLabel = null;
            }

            if (TopSeparatorView != null) {
                TopSeparatorView.Dispose ();
                TopSeparatorView = null;
            }
        }
    }
}