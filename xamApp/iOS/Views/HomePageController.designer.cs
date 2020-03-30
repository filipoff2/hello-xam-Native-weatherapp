// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherApp.iOS.Views
{
    [Register ("HomePageController")]
    partial class HomePageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WeatherApp.iOS.RotatingImageView IconImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WeatherApp.iOS.Utility.CustomButton SearchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SearchTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (IconImageView != null) {
                IconImageView.Dispose ();
                IconImageView = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }

            if (SearchTextField != null) {
                SearchTextField.Dispose ();
                SearchTextField = null;
            }
        }
    }
}