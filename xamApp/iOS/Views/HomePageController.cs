using System;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using WeatherApp.iOS.Utility;
using WeatherApp.Resources;
using WeatherApp.ViewModels;

namespace WeatherApp.iOS.Views
{
    public partial class HomePageController : UIViewController
    {
        const double AnimationInterval = 0.25;
        object[] _bindings;
        Theme theme = Theme.Default;

        public HomePageController(IntPtr ptr) : base(ptr) { }
        public HomeViewModel ViewModel { get; set; }

        public UIView AnimationSourceView => SearchTextField;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = LocalizedStrings.CitySelectTitle;

            theme.StyleTextField(SearchTextField);
            SearchTextField.Placeholder = LocalizedStrings.SearchTextFieldPlaceholder;

            theme.StyleActionButton(SearchButton);
            SearchButton.SetTitle(LocalizedStrings.SearchButtonTitle, UIControlState.Normal);
            SearchButton.SetCommand(ViewModel.SearchCommand);

            _bindings = new object[]
            {
                this.SetBinding(() => ViewModel.SearchText, () => SearchTextField.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.IsLoading, () => IconImageView.IsRotating, BindingMode.OneWay)
            };

            // prepare for initial for animation
            SearchButton.Hidden = true;
            SearchTextField.Hidden = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController?.SetNavigationBarHidden(true, animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            View.LayoutIfNeeded();
            SearchButton.Hidden = false;
            SearchTextField.Hidden = false;

            UIView.AnimateNotify(0.5f, 0.1f, 0.5f, 0, 0, () =>
            {
                View.LayoutIfNeeded();
            }, null);
        }
    }
}

