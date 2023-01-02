
global using VowsApp.Views;
global using VowsApp.Models;
global using VowsApp.Controls;
global using VowsApp.ViewModels;

using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using VowsApp.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace VowsApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCompatibility()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("DMSans-Bold-700.ttf", "DMSansBold");
                fonts.AddFont("Manrope-Bold.ttf", "ManropeBold");
                fonts.AddFont("DMSans-Medium-500.ttf", "DMSansMedium");
                fonts.AddFont("DMSans-Regular-400.ttf", "DMSansRegular");
			});

        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
            handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.Renderers.CustomShellRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessDatePicker), typeof(VowsApp.Platforms.Android.Renderers.BorderlessDatePickerRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessTimePicker), typeof(VowsApp.Platforms.Android.Renderers.BorderlessTimePickerRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessEditor), typeof(VowsApp.Platforms.Android.Renderers.BorderlessEditorRenderer));
#endif
#if IOS
            handlers.AddHandler(typeof(Shell), typeof(Platforms.iOS.Renderers.CustomShellRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessDatePicker), typeof(VowsApp.Platforms.iOS.Renderers.BorderlessDatePickerRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessTimePicker), typeof(VowsApp.Platforms.iOS.Renderers.BorderlessTimePickerRenderer));
            handlers.AddCompatibilityRenderer(typeof(BorderlessEditor), typeof(VowsApp.Platforms.iOS.Renderers.BorderlessEditorRenderer));
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        //Register Dependency Services
        
        builder.Services.AddTransient<LocationService>();
        builder.Services.AddTransient<ApiServiceHandler>();

        builder.Services.AddTransient<SignInPageViewModel>();
        builder.Services.AddTransient<SignInPage>();

        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddTransient<SignUpPage>();

        builder.Services.AddTransient<CountryListPopup>();
        builder.Services.AddTransient<CountryListPopupViewModel>();

        builder.Services.AddTransient<BillSummaryPage>();
        builder.Services.AddTransient<BillSummaryPageViewModel>();

        builder.Services.AddTransient<WhatsIncludedPopup>();
        builder.Services.AddTransient<WhatsIncludedPopupViewModel>();

        builder.Services.AddTransient<SelectServiceListPage>();
        builder.Services.AddTransient<SelectServiceListPageViewModel>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageViewModel>();

        builder.Services.AddTransient<OrderConfirmationPage>();
        builder.Services.AddTransient<OrderConfirmationPageViewModel>();

        builder.Services.AddTransient<OnboardingPage>();
        builder.Services.AddTransient<OnboardingPageViewModel>();

        builder.Services.AddTransient<SearchLocationPage>();
        builder.Services.AddTransient<SearchLocationPageViewModel>();

        builder.Services.AddTransient<AddressBookPage>();
        builder.Services.AddTransient<AddressBookPageViewModel>();

        return builder.Build();
	}
}
