using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
using GalaSoft.MvvmLight.Helpers;
using Java.Lang;
using Java.Math;
using Microsoft.Practices.ServiceLocation;
using WeatherApp.Droid.Navigation;
using WeatherApp.Droid.Utility;
using WeatherApp.Resources;
using WeatherApp.ViewModels;
using String = Java.Lang.String;

namespace WeatherApp.Droid
{   
    [Activity(Label = "WeatherApp", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class HomePageActivity : Activity, INavigationView
    {
        private readonly List<Binding> bindings = new List<Binding>();
        private readonly NavigationHelper navigationHelper = new NavigationHelper();

        public NavigationHelper Helper { get { return navigationHelper; } }

        private HomeViewModel ViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

        private EditText etCitySearch;


        public EditText EtCitySearch
        {
            get
            {
                return etCitySearch ??
                       (etCitySearch = FindViewById<EditText>(
                           Resource.Id.etCitySearch));
            }
        }

        private Button btnSearch;

        public Button BtnSearch
        {
            get
            {
                return btnSearch ??
                       (btnSearch = FindViewById<Button>(
                           Resource.Id.btnSearch)
                     );
            }
        }

        private RotateImageView ivIcon;

        public RotateImageView IvIcon
        {
            get
            {
                return ivIcon ??
                       (ivIcon = FindViewById<RotateImageView>(
                           Resource.Id.ivIcon
                       ));
            }
        }

        protected override void OnResume()
        {
            Helper.OnResume(this);
            base.OnResume();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HomePage);

            BtnSearch.Text = LocalizedStrings.SearchButtonTitle;
            EtCitySearch.Hint = LocalizedStrings.SearchTextFieldPlaceholder;

            setUiParams();

            BtnSearch.SetCommand(ViewModel.SearchCommand);
            bindings.Add(this.SetBinding(
                () => ViewModel.SearchText,
                () => EtCitySearch.Text,
                BindingMode.TwoWay));

            bindings.Add(this.SetBinding(
                () => ViewModel.IsLoading,
                () => IvIcon.IsRotating,
                BindingMode.OneWay));
        }

        private void setUiParams()  
        {
            Color color = Color.Rgb(204,204,255);
            setStrokeColor(EtCitySearch, color);
            setBackgroundDrawable(btnSearch, color);


        }
        private void setStrokeColor(View view, Color color)
        {
            GradientDrawable myGrad = (GradientDrawable)view.Background;
            myGrad.SetStroke(4, color);
        }

        private void setBackgroundDrawable(View view, Color color)
        {
            Drawable btnShape = this.GetDrawable(Resource.Drawable.btn_shape);
            btnShape.SetColorFilter(color, PorterDuff.Mode.SrcIn);
            view.SetBackgroundDrawable(btnShape);
        }
    }
}