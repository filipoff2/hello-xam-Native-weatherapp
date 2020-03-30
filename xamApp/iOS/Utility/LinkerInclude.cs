using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using Foundation;
using UIKit;

namespace xxxx
{
    /// <summary>
    /// This class is never actually executed, but when Xamarin linking is enabled it does how to ensure types and properties 
    /// are preserved in the deployed app.
    /// 
    /// Resources:
    /// http://www.itworksonmymachine.net/index.php/2015/04/20/xamarin-tips-and-tricks-2-beware-of-linking-and-reflection/
    /// http://blog.galasoft.ch/posts/2015/03/solving-the-event-not-found-issue-in-xamarin-mvvmlight-binding-and-commanding/
    /// https://github.com/MvvmCross/MvvmCross-Tutorials/blob/master/DailyDilbert/DailyDilbert.Touch/LinkerPleaseInclude.cs
    /// </summary>
    [Preserve]
    public class LinkerInclude
    {
        public void Include(UIButton uiButton)
        {
            uiButton.TouchUpInside += (s, e) => 
            uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
            uiButton.Selected = false;
        }

        public void Include(UIBarButtonItem barButton)
        {
            barButton.Clicked += (s, e) => 
            barButton.Title = barButton.Title + "";
        }

        public void Include(UITextField textField)
        {
            textField.Text = textField.Text + "";
            textField.EditingChanged += (sender, args) => { textField.Text = ""; };
        }

        public void Include(UITextView textView)
        {
            textView.Text = textView.Text + "";
            textView.Changed += (sender, args) => { textView.Text = ""; };
        }

        public void Include(UILabel label)
        {
            label.Text = label.Text + "";
        }

        public void Include(UIImageView imageView)
        {
            imageView.Image = new UIImage(imageView.Image.CGImage);
        }

        public void Include(UIDatePicker date)
        {
            date.Date = date.Date.AddSeconds(1);
            date.ValueChanged += (sender, args) => { date.Date = NSDate.Now; };
        }

        public void Include(UISlider slider)
        {
            slider.Value = slider.Value + 1;
            slider.ValueChanged += (sender, args) => { slider.Value = 1; };
        }

        public void Include(UISwitch sw)
        {
            sw.On = !sw.On;
            sw.ValueChanged += (sender, args) => { sw.On = false; };
        }

        public void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) => { var test = string.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems, e.OldStartingIndex); };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }
    }
}
