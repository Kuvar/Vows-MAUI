using VowsApp.Views;

namespace VowsApp;

public partial class AppShellOnboarding : Shell
{
	public AppShellOnboarding()
	{
		InitializeComponent();
        //Routings
        Routing.RegisterRoute(nameof(CountryListPopup), typeof(CountryListPopup));
        Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));


        Routing.RegisterRoute(nameof(BillSummaryPage), typeof(BillSummaryPage));
        Routing.RegisterRoute(nameof(WhatsIncludedPopup), typeof(WhatsIncludedPopup));
        Routing.RegisterRoute(nameof(SelectServiceListPage), typeof(SelectServiceListPage));
        Routing.RegisterRoute(nameof(OrderConfirmationPage), typeof(OrderConfirmationPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(OnboardingPage), typeof(OnboardingPage));
    }
}