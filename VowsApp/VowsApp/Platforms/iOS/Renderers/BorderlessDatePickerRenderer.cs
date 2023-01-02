using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using System.ComponentModel;
using UIKit;

namespace VowsApp.Platforms.iOS.Renderers
{
    public class BorderlessDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}
