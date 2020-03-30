using System;
using Foundation;
using UIKit;


namespace WeatherApp.iOS.Utility
{
    [Register("CustomButton")]
    public class CustomButton : UIButton
    {
        public UIColor ColorForNormalState { get; } = UIColor.FromRGB(204, 204, 255); 
        public UIColor ColorForDisabledState { get; } = UIColor.Gray;

        public CustomButton(IntPtr ptr) : base(ptr)
        {
            
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            UpdateBackgroundColor();
        }

        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                UpdateBackgroundColor();
            }
        }

        void UpdateBackgroundColor()
        {
            if (Enabled)
            {
                BackgroundColor = ColorForNormalState;
            }
            else
            {
                BackgroundColor = ColorForDisabledState;
            }

        }
    }
}
