using Microsoft.Maui.Controls.Shapes;

namespace VowsApp.Views;

public partial class AddressBookPage : ContentPage
{
    AddressBookPageViewModel _viewModel;
    public AddressBookPage(AddressBookPageViewModel viewModel)
	{
		InitializeComponent();

        this.BindingContext= _viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetAddressList();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        SetAddressList();
    }

    private void SetAddressList()
    {
        test.Children.Clear();

        StackLayout stack = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
        };

        for (int i = 0; i < _viewModel.Addresses.Count; i++)
        {
            stack.Children.Add(view(_viewModel.Addresses[i], _viewModel.Addresses.Count, i));
        }

        test.Children.Add(stack);
    }

    private IView view(AddressModel address, int totalCount, int currentIndex)
    {
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition{ Height = new GridLength(2,GridUnitType.Auto) },
                new RowDefinition{ Height = new GridLength(40) },
            },
            ColumnDefinitions = {
                new ColumnDefinition { Width = new GridLength(30) },
                new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(30) },
            }
        };
        Grid buttonsGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition{ Height = new GridLength(2,GridUnitType.Star) },
                new RowDefinition{ Height = new GridLength(2,GridUnitType.Star) },
            },
            RowSpacing = 10
        };
        Image editImage = new Image { Source = "edit.svg", HeightRequest = 16, };
        Image deleteImage = new Image { Source = "trash.svg", HeightRequest = 16, };

        TapGestureRecognizer editGestureRecognizer = new TapGestureRecognizer();
        TapGestureRecognizer deleteGestureRecognizer = new TapGestureRecognizer();

        editImage.GestureRecognizers.Add(editGestureRecognizer);
        editGestureRecognizer.Command = _viewModel.EditAddressCommand;
        editGestureRecognizer.CommandParameter = address;

        deleteImage.GestureRecognizers.Add(deleteGestureRecognizer);
        deleteGestureRecognizer.Command =  _viewModel.DeleteAddressCommand; 
        deleteGestureRecognizer.CommandParameter = address;

        buttonsGrid.Add(
            new Border
            {
                Stroke = Color.FromArgb("#00000000"),
                Background = Color.FromArgb("#000000"),
                StrokeThickness = 1,
                Padding = new Thickness(3),
                HeightRequest= 30,
                WidthRequest= 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(8, 8, 8, 8)
                },
                Content = editImage
            }, 0, 0);
        buttonsGrid.Add(
            new Border
            {
                Stroke = Color.FromArgb("#00000000"),
                Background = Color.FromArgb("#000000"),
                StrokeThickness = 1,
                HeightRequest = 30,
                WidthRequest = 30,
                Padding = new Thickness(3),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(8, 8, 8, 8)
                },
                Content = deleteImage
            }, 0, 1);
        grid.Add(new RadioButton { GroupName = "address" }, 0, 0);
        grid.Add(
            new StackLayout 
            { 
                Orientation= StackOrientation.Vertical,
                Spacing = 10,
                Padding= new Thickness(8,5),
                Children =
                {
                    new Label
                    {
                        Text = address.Name,
                        FontSize= 16,
                        FontAttributes= FontAttributes.Bold,
                        TextColor= Color.FromArgb("#000000"),
                        FontFamily = "DMSansMedium"

                        //Style = (Style)Application.Current.Resources["DmSansMediumLabelBlack16"]
                    },
                    new Label
                    {
                        Text = address.Address,
                        FontSize= 16,
                        FontAttributes= FontAttributes.None,
                        TextColor= Color.FromArgb("#000000"),
                        FontFamily = "DMSansRegular"
                        //Style = (Style)Application.Current.Resources["DmSansLabelBlackVows16"]
                    },
                    new Label
                    {
                        Text = address.ContactNumber,
                        FontSize= 16,
                        FontAttributes= FontAttributes.Bold,
                        TextColor= Color.FromArgb("#000000"),
                        FontFamily = "DMSansMedium"
                        //Style = (Style)Application.Current.Resources["DmSansMediumLabelBlack16"]
                    }
                }
            }, 1, 0);
        grid.Add(buttonsGrid, 2, 0);

        if((currentIndex + 1) < totalCount)
        {
            var sep = new BoxView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                Color = Color.FromArgb("#000000"),
                HeightRequest = 2,
            };
            Grid.SetRow(sep,1);
            Grid.SetColumnSpan(sep,3);
            grid.Add(sep);
        }
        return grid;
    }

    private void StackLayout_ChildAdded(object sender, ElementEventArgs e)
    {
        
        var stack = (StackLayout)sender;

        

        //Label label = sender.Parent.FindByName("labelA");
    }

}