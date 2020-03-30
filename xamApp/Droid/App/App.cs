using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using GalaSoft.MvvmLight.Views;
using Plugin.CurrentActivity;
using WeatherApp.Droid.Navigation;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public  class App : Application, Application.IActivityLifecycleCallbacks
    {
        private InitCommon enviroment;

        public App(IntPtr handle, JniHandleOwnership transer)
            :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);

            enviroment = new InitCommonDroid();
            enviroment.Register();
            enviroment.Run();
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}