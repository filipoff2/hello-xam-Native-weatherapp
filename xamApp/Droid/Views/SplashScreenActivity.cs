using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherApp.Droid.Views
{
    [Activity(MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/SplashScreen", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();

            Task.Run(async () =>
            {
                StartActivity(new Intent(Application.Context, typeof(HomePageActivity)));
            });
        }
    }
}