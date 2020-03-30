using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using WeatherApp.Droid;

namespace WeatherApp.Droid.Utility
{
    public class RotateImageView : ImageView
    {
        private bool isRotating;
        Bitmap bitmapScaled;
        Bitmap bitmapOrg;

        public bool IsRotating
        {
            get { return isRotating; }
            set
            {
                if (value != isRotating)
                {
                    isRotating = value;
                    SetAnimation(value);


                }
            }
        }
        protected RotateImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public RotateImageView(Context context) : base(context)
        {
            
        }

        public RotateImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        void Spin()
        {
            if(!isRotating) return;

            Animation rotation = AnimationUtils.LoadAnimation(this.Context, Resource.Animation.image_rotate);
            this.StartAnimation(rotation);
        }
    

        void SetAnimation(bool animating)
        {
            if (animating)
            {
                Spin();
            }
            else
            {
                this.ClearAnimation();
            }
        }

    }
}