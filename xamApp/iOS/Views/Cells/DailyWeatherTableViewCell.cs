using System;
using Foundation;
using SDWebImage;
using UIKit;

namespace WeatherApp.iOS.Views
{
    public partial class DailyWeatherTableViewCell : UITableViewCell
    {
        protected DailyWeatherTableViewCell(IntPtr handle) : base(handle) { }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            DayLabel.AccessibilityIdentifier = "DayLabel";
            DailyTemperatureLabel.AccessibilityIdentifier = "DailyTemperatureLabel";
            NightTemperatureLabel.AccessibilityIdentifier = "NightTemperatureLabel";
        }

		public void Update(string dayOfWeek, NSUrl imageUrl, int dailyTemperature, int nightTemperature)
		{
			DayLabel.Text = dayOfWeek;
            WeatherIconImageView.SetImage(imageUrl);
            DailyTemperatureLabel.Text = dailyTemperature.ToString();
            NightTemperatureLabel.Text = nightTemperature.ToString();
		}
    }
}
