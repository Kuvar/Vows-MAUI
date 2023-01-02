using Android.Content;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowsApp.Platforms.Android.Renderers
{
    public class BorderlessTimePickerRenderer : TimePickerRenderer
    {
        public BorderlessTimePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);

                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Color.FromHex("#00FFFFFF").ToAndroid());
                this.Control.SetBackgroundDrawable(gd);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}
