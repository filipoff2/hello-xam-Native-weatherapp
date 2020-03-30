using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using Square.Picasso;
using WeatherApp.Droid;
using WeatherApp.Droid.Navigation;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Droid
{
    [Activity(Label = "WeatherApp", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class DetailsActivity : Activity, INavigationView
    {
        private readonly List<Binding> bindings = new List<Binding>();
        public ObservableRecyclerAdapter<DetailsViewModel.DailyWeatherData, CachingViewHolder> _adapterDaily;
        public ObservableRecyclerAdapter<DetailsViewModel.HourlyWeatherData, CachingViewHolder> _adapterHourly;
        private IMenuItem favItem;
        public NavigationHelper Helper { get; } = new NavigationHelper();

        private DetailsViewModel ViewModel => ServiceLocator.Current.GetInstance<DetailsViewModel>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.DetailsPage);
            ViewModel.LoadDataCommand.Execute(null);

            bindings.Add(this.SetBinding(
                () => ViewModel.CityName,
                () => TvCityName.Text,
                BindingMode.OneWay));

            bindings.Add(this.SetBinding(
                () => ViewModel.CurrentTemperature,
                () => CurrentTemperature,
                BindingMode.OneWay));

            bindings.Add(this.SetBinding(
                () => ViewModel.TodayDayName,
                () => TvTodayName.Text,
                BindingMode.OneWay));


            

            _adapterDaily =
                ViewModel.DailyWeatherList.GetRecyclerAdapter(BindingViewHolderDaily, Resource.Layout.DailyWeatherAdapter);
            RecyclerDaily.SetLayoutManager(new LinearLayoutManager(this));
            RecyclerDaily.SetAdapter(_adapterDaily);

            _adapterHourly =
                ViewModel.HourlyWeatherList.GetRecyclerAdapter(BindingViewHolderHourly, Resource.Layout.HourlyWeatherAdapter);
            RecyclerHourly.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false));
            RecyclerHourly.SetAdapter(_adapterHourly);
           


            Picasso.With(this).Load(ViewModel.WeatherIconBasePath + ViewModel.CurrentWeatherIconName + ".png").Into(IvIcon);

        }

        private void BindingViewHolderDaily(CachingViewHolder holder, DetailsViewModel.DailyWeatherData viewModel,
            int position)
        {
            var day = holder.FindCachedViewById<TextView>(Resource.Id.tvDay);
            day.Text = viewModel.dayOfWeek;

            var min = holder.FindCachedViewById<TextView>(Resource.Id.tvTempNight);
            min.Text = viewModel.nightTemperature.ToString();
            var max = holder.FindCachedViewById<TextView>(Resource.Id.tvTempDay);
            max.Text = viewModel.dailyTemperature.ToString();

            var icon = holder.FindCachedViewById<ImageView>(Resource.Id.icon);

            Picasso.With(this).Load(ViewModel.WeatherIconBasePath + viewModel.iconName + ".png").Into(icon);
        }

        private void BindingViewHolderHourly(CachingViewHolder holder, DetailsViewModel.HourlyWeatherData viewModel,
            int position)
        {
            var day = holder.FindCachedViewById<TextView>(Resource.Id.tvHour);
            day.Text = viewModel.hour;

            var min = holder.FindCachedViewById<TextView>(Resource.Id.tvTemp);
            min.Text = viewModel.temperature.ToString();

            var icon = holder.FindCachedViewById<ImageView>(Resource.Id.ivIcon);

            Picasso.With(this).Load(ViewModel.WeatherIconBasePath + viewModel.iconName + ".png").Into(icon);
        }
    }
}