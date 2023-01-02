using UIKit;
using CoreGraphics;
using System.ComponentModel;
using Microsoft.Maui.Platform;
using System.Runtime.InteropServices;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace VowsApp.Platforms.iOS.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomTabBarAppearanceTracker();
        }
    }

    public class CustomTabBarAppearanceTracker : ShellTabBarAppearanceTracker, IShellTabBarAppearanceTracker
    {
        void IShellTabBarAppearanceTracker.SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            base.SetAppearance(controller, appearance);
            UITabBar tabBar = controller.TabBar;
            controller.TabBar.ItemPositioning = UITabBarItemPositioning.Centered;
            if (tabBar.Items != null)
            {
                foreach (var item in tabBar.Items)
                {
                    item.ImageInsets = new UIEdgeInsets(4, 4, 4, 4);
                }
            }
            CGSize size = new CGSize(UIScreen.MainScreen.Bounds.Width / (tabBar.Items?.Count() ?? 5), tabBar.Bounds.Size.Height - 1);
            CGSize lineSize = new CGSize(UIScreen.MainScreen.Bounds.Width / (tabBar.Items?.Count() ?? 5), 3);
            UITabBar.Appearance.SelectionIndicatorImage = GetImageWithColorPosition(Color.FromArgb("#083B57").ToPlatform(), new CGSize(UIScreen.MainScreen.Bounds.Width / (tabBar.Items?.Count() ?? 5), tabBar.Bounds.Size.Height - 1), new CGSize(UIScreen.MainScreen.Bounds.Width / (tabBar.Items?.Count() ?? 5), 3));
            UITabBar.Appearance.SelectionIndicatorImage.CreateResizableImage(new UIEdgeInsets(0, 0, 0, 0));
        }

        UIImage GetImageWithColorPosition(UIColor color, CGSize size, CGSize lineSize)
        {
            var rect = new CGRect(0, 0, size.Width, size.Height + 1);

            var width = (int)UIScreen.MainScreen.Bounds.Width;//width in units  
            var height = (int)UIScreen.MainScreen.Bounds.Height;//height in units  

            int TopPad = 0;
            NFloat x = 0;
            NFloat lineWidth = 0;
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                TopPad = 5;
                x = 40;
                lineWidth = lineSize.Width - 75;
            }
            else
            {
                TopPad = 10;
                x = 13;
                lineWidth = lineSize.Width - 26;
            }

            var lineSizeNew = lineSize.Height;
            var rectLine = new CGRect(x, size.Height - TopPad, lineWidth, lineSize.Height);

            UIGraphics.BeginImageContextWithOptions(new CGSize(size.Width, size.Height + 1), false, 0);
            UIColor.Clear.SetFill();
            UIGraphics.RectFill(rect);
            color.SetFill();
            UIGraphics.RectFill(rectLine);
            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;
        }
    }
}
