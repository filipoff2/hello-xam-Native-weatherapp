using GalaSoft.MvvmLight;
using UIKit;
using WeatherApp.iOS.Utility;
using WeatherApp.iOS.Views;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;

namespace WeatherApp.iOS
{
    /// <summary>
    /// Creates view controllers from viewModels provided by the AppNavigator.
    /// </summary>
    class ViewPresenter : IViewPresenter
    {
        private UINavigationController _root;

        public void Show(ViewModelBase viewModel, NavigationRequest request)
        {
            switch (viewModel)
            {
                case HomeViewModel vm1:
                    {
                        var vc = Instantiate<HomePageController>();
                        vc.ViewModel = vm1;
                        _root.PushViewController(vc, true);
                        return;
                    }
                case DetailsViewModel vm2:
                    {
                        var vc = Instantiate<DetailsPageController>();
                        vc.ViewModel = vm2;
                        _root.Delegate = new CustomTransitionCoordinator();
                        _root.PushViewController(vc, true);
                        return;
                    }
            }
        }

        public T Instantiate<T>() where T : UIViewController
        {
            var name = typeof(T).Name;
            var storybard = UIStoryboard.FromName(name, null);
            var vc = storybard.InstantiateInitialViewController() as T;
            return vc;
        }

        public UIWindow Setup()
        {
            _root = new UINavigationController();
            var window = new UIWindow();
            window.RootViewController = _root;
            window.MakeKeyAndVisible();
            return window;
        }
    }
}