using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherApp.Common;
using WeatherApp.Models;
using WeatherApp.Resources;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {

		private readonly IWeatherApi _api;
        
		private bool _isLoading;
        bool _isFavorite;

        public CityLong CityLongModel { private get; set; }

        public string CityName 
        { 
            get { return CityLongModel?.Name; }
        }

        public string CurrentWeatherIconName 
        { 
            get  { return CityLongModel.Weather.Length > 0 ? CityLongModel.Weather[0].Icon : ""; }
        }

        public double CurrentTemperature 
        { 
            get { return convertTemperature(CityLongModel.Statistics.Temp); }
        }

        public string TodayMaxTemperature
        {
            get { return convertTemperature(CityLongModel.Statistics.TempMax).ToString(); }
        }

        public string TodayMinTemperature
        {
            get { return convertTemperature(CityLongModel.Statistics.TempMin).ToString(); }
        }

        public string TodayDayName
        {
            get { return CityLongModel.Timestamp.DayOfWeek.ToString(); }
        }

        public ObservableCollection<DailyWeatherData> DailyWeatherList { get; }
        public ObservableCollection<HourlyWeatherData> HourlyWeatherList { get; private set; }
        public string WeatherIconBasePath { get; private set; }
        public RelayCommand LoadDataCommand { get; private set; }
        

		public bool IsLoading
		{
			get { return _isLoading; }
			private set 
            { 
                Set(ref _isLoading, value); 
			}
		}


        public DetailsViewModel(IDialogService dialogService, IRoutingService navigationService, IWeatherApi api) 
            : base(dialogService, navigationService)
		{
            this._api = api;

            WeatherIconBasePath = ApiConstants.iconPath;

            DailyWeatherList = new ObservableCollection<DailyWeatherData>();
            HourlyWeatherList = new ObservableCollection<HourlyWeatherData>();

			LoadDataCommand = new RelayCommand(async () => await LoadData());
            
		}

        async Task LoadData()
		{
            HourlyWeatherList = new ObservableCollection<HourlyWeatherData>(); // HourlyWeatherList.Clear(); cause crash
			DailyWeatherList.Clear();

			try
			{
                IsLoading = true;

                // get long term weather
                var longTermWeather = await _api.GetLongTermWeather( CityName);

                for (int i = 1; i < longTermWeather.DailyWeatherList.Count; i++) // skip todays weather
                    DailyWeatherList.Add(new DailyWeatherData(longTermWeather.DailyWeatherList[i]));

                

				// get hourly weather
				//var hourlyWeather = await _api.GetHourlyWeather(_measureSystem.UseMetricSystem, CityName, _hourlyWeatherHoursCount);

				//foreach (var weather in hourlyWeather.HourWeatherDetailsList)
				//	HourlyWeatherList.Add(new HourlyWeatherData(weather));
			}
			catch
			{
                await ShowErrorDialog();
			}
			finally
			{
				IsLoading = false;
			}
		}

        public static int convertTemperature(double temperature) 
        {
            return (int)Math.Round(temperature);
        }

		public struct DailyWeatherData
		{
			public string iconName;
			public string dayOfWeek;
			public int dailyTemperature;
			public int nightTemperature;

			public DailyWeatherData(DailyWeather data)
			{
				iconName = data.Weather.Length > 0 ? data.Weather[0].Icon : "";
				dayOfWeek = data.Timestamp.DayOfWeek.ToString();
                dailyTemperature = DetailsViewModel.convertTemperature(data.Temperatures.Max);
				nightTemperature = DetailsViewModel.convertTemperature(data.Temperatures.Min);
			}
		}

		public struct HourlyWeatherData
		{
			public string iconName;
			public string hour;
			public int temperature;

            public HourlyWeatherData(HourWeatherDetails data)
            {
                iconName = data.Weather.Length > 0 ? data.Weather[0].Icon : "";
                hour = data.Timestamp.Hour > 9 ? data.Timestamp.Hour.ToString() : "0" + data.Timestamp.Hour.ToString();
                temperature = DetailsViewModel.convertTemperature(data.Statistics.Temp);
            }
		}
    }
}
