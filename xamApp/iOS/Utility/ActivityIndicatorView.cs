using Foundation;
using System;
using UIKit;

namespace WeatherApp.iOS
{
    public partial class ActivityIndicatorView : UIActivityIndicatorView
    {
        public ActivityIndicatorView (IntPtr handle) : base (handle)
        {
        }

        public bool IsLoading
        {
            get => !Hidden;
            set
            {
                Hidden = !value;
                if (value)
                {
                    StartAnimating();
                }
            }
        }
    }
}