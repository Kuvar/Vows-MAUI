using VowsApp.Controls;
using Microsoft.Maui.Handlers;

namespace VowsApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
				handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
				handler.PlatformView.Layer.BackgroundColor = UIKit.UIColor.Clear.CGColor;
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        MainPage = new AppShellOnboarding();
	}
}
