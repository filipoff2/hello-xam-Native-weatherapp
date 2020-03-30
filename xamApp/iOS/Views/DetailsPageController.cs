using System;
using System.Globalization;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using WeatherApp.iOS.Utility;
using WeatherApp.iOS.Views.Cells;
using WeatherApp.ViewModels;

namespace WeatherApp.iOS.Views
{
    public partial class DetailsPageController : UIViewController
    {      
        object[] _bindings;
        public DetailsViewModel ViewModel { get; set; }

        public DetailsPageController(IntPtr ptr) : base(ptr) { }

        private double _currentTemperature;

        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                _currentTemperature = value;
                CurrentTemperatureLabel.Text = GetTemperatureString(value);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "";

            ViewModel.LoadDataCommand.Execute(null);
            UIColor lineColor = Theme.MainColor;

            TopSeparatorView.BackgroundColor = lineColor;
            BottomSeparatorView.BackgroundColor = lineColor;

            _bindings = new object[]
            {
                this.SetBinding(() => ViewModel.CityName, () => CityName.Text, BindingMode.OneWay),
                this.SetBinding(() => ViewModel.CurrentTemperature, () => CurrentTemperature, BindingMode.OneWay),
                this.SetBinding(() => ViewModel.TodayDayName, () => TodayDayNameLabel.Text, BindingMode.OneWay),
                this.SetBinding(() => ViewModel.TodayMaxTemperature, () => TodayMaxTemperatureLabel.Text, BindingMode.OneWay),
                this.SetBinding(() => ViewModel.TodayMinTemperature, () => TodayMinTemperatureLabel.Text, BindingMode.OneWay),
                this.SetBinding(() => ViewModel.IsLoading, () => ActivityIndicator.IsLoading, BindingMode.OneWay),
            };

			DailyWeatherTableView.Source = ViewModel.DailyWeatherList.GetTableViewSource(
				CreateTaskCell,
				BindWeatherDataCell
			);

			HourlyWeatherCollectionView.Source = ViewModel.HourlyWeatherList.GetCollectionViewSource<DetailsViewModel.HourlyWeatherData, HourWeatherCollectionViewCell>(
            	BindHourWeatherViewCell,
            	null,
            	nameof(HourWeatherCollectionViewCell));

            // workaround for sad MVVM light behaviour registering class on it's own
            // force source to register the cell
            HourlyWeatherCollectionView.Source.GetItemsCount(HourlyWeatherCollectionView, 0);
            // override the registration
            HourlyWeatherCollectionView.RegisterNibForCell(HourWeatherCollectionViewCell.Nib, nameof(HourWeatherCollectionViewCell));

            CityName.AccessibilityIdentifier = "CityName";
            
        }

		private void BindHourWeatherViewCell(HourWeatherCollectionViewCell cell, DetailsViewModel.HourlyWeatherData weather, NSIndexPath path)
		{
            cell.Update(weather.hour, GetWeatherIconUrl(weather.iconName), weather.temperature.ToString());
		}
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController?.SetNavigationBarHidden(false, animated);
        }

        private UITableViewCell CreateTaskCell(NSString cellIdentifier)
        {
            return DailyWeatherTableView.DequeueReusableCell(nameof(DailyWeatherTableViewCell)) as DailyWeatherTableViewCell;
        }

        private void BindWeatherDataCell(UITableViewCell cell, DetailsViewModel.DailyWeatherData weather, NSIndexPath path)
        {
            var weatherCell = cell as DailyWeatherTableViewCell;

            weatherCell.Update(
                weather.dayOfWeek,
                GetWeatherIconUrl(weather.iconName),
                weather.dailyTemperature,
                weather.nightTemperature);
        }

		private string GetTemperatureString(double temperature)
		{
            var temperatureUnits = NSUnitTemperature.Celsius;

            NSMeasurement<NSUnitTemperature> measurement = new NSMeasurement<NSUnitTemperature>(temperature, temperatureUnits);
			return temperature.ToString() + measurement.Unit.Symbol;
		}

        private NSUrl GetWeatherIconUrl(string iconName)
        {
            return new NSUrl(ViewModel.WeatherIconBasePath + iconName + ".png");
        }
    }
}