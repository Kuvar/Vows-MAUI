using VowsApp.Views;

namespace VowsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Routings
        
        Routing.RegisterRoute(nameof(OrderConfirmationPage), typeof(OrderConfirmationPage));
        Routing.RegisterRoute(nameof(SearchLocationPage), typeof(SearchLocationPage));
        Routing.RegisterRoute(nameof(WhatsIncludedPopup), typeof(WhatsIncludedPopup));
        Routing.RegisterRoute(nameof(AddressBookPage), typeof(AddressBookPage));
        Routing.RegisterRoute(nameof(BillSummaryPage), typeof(BillSummaryPage));
        Routing.RegisterRoute(nameof(OnboardingPage), typeof(OnboardingPage));
        Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
