using System;
using Android.Content;
using GalaSoft.MvvmLight;
using Plugin.CurrentActivity;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.Utils;
using WeatherApp.ViewModels;

namespace WeatherApp.Droid.Navigation
{
    public class ViewPresenter : IViewPresenter
    {
        public INavigationView CurrentView => CrossCurrentActivity.Current.Activity as INavigationView;

        public void Show(ViewModelBase viewModel, NavigationRequest request)
        {
            // First activity will be displayed elsewhere
            if (CurrentView?.Helper?.CurrentActivity == null) return;

            Type activityType;

            switch(viewModel)
            {
                case HomeViewModel vm1:
                    {
                        activityType = typeof(HomePageActivity);
                        break;
                    }
                case DetailsViewModel vm2:
                    {
                        activityType = typeof(DetailsActivity);
                        break;
                    }
                default:
                    {
                        Logger.LogError("Unknown viewModel");
                        return;
                    }
            }

            var intent = new Intent(CurrentView.Helper.CurrentActivity, activityType);
            CurrentView.Helper.CurrentActivity.StartActivity(intent);
            CurrentView.Helper.NextPageKey = request.Key;
        }
    }
}
