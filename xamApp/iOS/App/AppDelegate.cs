using System;
using Foundation;
using UIKit;
using WeatherApp.iOS.Utility;
using WeatherApp.Utils;

namespace WeatherApp.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private InitCommoniOS init;
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            init = new InitCommoniOS();
            init.Register();
            init.Run();

            Window = init.Window;
            Window.TintColor = Theme.TextColor;
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();

            return true;
        }

    }
}