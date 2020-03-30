using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WeatherApp.Droid
{
    public partial class DetailsActivity: Activity

    {
        private TextView tvCityName;

        public TextView TvCityName
        {
            get
            {
                return tvCityName ??
                       (tvCityName = FindViewById<TextView>(
                           Resource.Id.tvCityName));
            }
        }

        private TextView tvTodayName;

        public TextView TvTodayName
        {
            get
            {
                return tvTodayName ??
                       (tvTodayName = FindViewById<TextView>(
                           Resource.Id.tvTodayName));
            }
        }


        private TextView tvTemp;

        public TextView TvTemp
        {
            get
            {
                return tvTemp ??
                       (tvTemp = FindViewById<TextView>(
                           Resource.Id.tvWeatherTemp));
            }
        }

        private int _currentTemperature;

        public int CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                _currentTemperature = value;
                TvTemp.Text = value.ToString() + GetString(Resource.String.celsius);
            }
        }

        private ImageView _ivIcon;

        public ImageView IvIcon
        {
            get
            {
                return _ivIcon ??
                       (_ivIcon = FindViewById<ImageView>(
                           Resource.Id.ivWeatherIcon));
            }
        }

        private RecyclerView _recyclerDaily;

        public RecyclerView RecyclerDaily
        {
            get
            {
                return _recyclerDaily ??
                       (_recyclerDaily = FindViewById<RecyclerView>(Resource.Id.recyclerDily));
            }
        }


        private RecyclerView _recyclerHourly;

        public RecyclerView RecyclerHourly
        {
            get
            {
                return _recyclerHourly ??
                       (_recyclerHourly = FindViewById<RecyclerView>(Resource.Id.recyclerHourly));
            }
        }

   
    }
}