using System;

using Foundation;
using SDWebImage;
using UIKit;
using WeatherApp.ViewModels;

namespace WeatherApp.iOS.Views.Cells
{
    public partial class HourWeatherCollectionViewCell : UICollectionViewCell
    {
        public static readonly UINib Nib;

        static HourWeatherCollectionViewCell()
        {
            Nib = UINib.FromName(nameof(HourWeatherCollectionViewCell), NSBundle.MainBundle);
        }

        protected HourWeatherCollectionViewCell(IntPtr handle) : base(handle)
        {
        }

        public void Update(string hour, NSUrl iconUrl, string temperature)
		{
			HourLabel.Text = hour;
			IconImageView.SetImage(iconUrl);
			TemperatureLabel.Text = temperature;
		}
    }
}
