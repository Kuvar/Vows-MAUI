using CommunityToolkit.Maui.Views;

namespace VowsApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        catch (Exception ex)
        {
            throw;
        }
	}

    private void CarouselPositionChanged(object sender, PositionChangedEventArgs e)
	{
        var carousel = sender as CarouselView;
        var views = carousel.VisibleViews;

        if (views.Count > 0)
        {
            carousel.PeekAreaInsets = 100;

            var stack0 = views[0].FindByName<StackLayout>("CarouselStack");
            var lbl0 = views[0].FindByName<Label>("CarouselLabel");
            var img0 = views[0].FindByName<Image>("CarouselImage");

            stack0.WidthRequest = 180;
            img0.HeightRequest = 180;
            lbl0.FontSize = 16;

            var stack = views[1].FindByName<StackLayout>("CarouselStack");
            var lbl = views[1].FindByName<Label>("CarouselLabel");
            var img = views[1].FindByName<Image>("CarouselImage");

            stack.WidthRequest = 190;
            img.HeightRequest = 200;
            lbl.FontSize = 20;
            
        }
    }
}