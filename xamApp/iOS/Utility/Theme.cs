using System;
using CoreGraphics;
using UIKit;

namespace WeatherApp.iOS.Utility
{
    public class Theme
    {
        float SmallBorderWidth = 3.0f;
        float SmallCornerRadius = 5.0f;
        public static UIColor MainColor = UIColor.FromRGB(204, 204, 255);
        public static UIColor TextColor = UIColor.Purple;

        void SetBorder(UIView view, UIColor color, float width)
        {
            view.Layer.BorderColor = color.CGColor;
            view.Layer.BorderWidth = width;
        }

        void SetRoundCorners(UIView view, float radius)
        {
            view.Layer.CornerRadius = radius;
            view.Layer.MasksToBounds = true;
        }

        public void StyleTextField(UITextField textField)
        {
            textField.BorderStyle = UITextBorderStyle.None;
            textField.LeftView = new UIView(new CGRect(0, 0, 10, 10));
            textField.LeftViewMode = UITextFieldViewMode.Always;
            textField.TextColor = TextColor;

            StyleRoundBorder(textField);
        }

        internal void StyleRoundBorder(UIView view)
        {
            SetBorder(view, MainColor, SmallBorderWidth);
            SetRoundCorners(view, SmallBorderWidth);
        }

        public void StyleActionButton(UIButton button)
        {
            SetRoundCorners(button, SmallCornerRadius);
            button.BackgroundColor = MainColor; 
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
        }

        public static Theme Default = new Theme();
    }
}
