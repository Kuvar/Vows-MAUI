namespace VowsApp.Views;

public partial class CountryListPopup : ContentPage
{
	public CountryListPopup()
	{
		InitializeComponent();

        this.BackgroundColor = Color.FromArgb("#80000000");
        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        var xamarinWidth = mainDisplayInfo.Width / mainDisplayInfo.Density;
        popupframe.WidthRequest = xamarinWidth;
    }
}