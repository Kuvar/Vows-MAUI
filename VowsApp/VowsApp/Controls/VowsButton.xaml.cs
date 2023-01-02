using System.Windows.Input;

namespace VowsApp.Controls;

public partial class VowsButton : ContentView
{
    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(
        nameof(ButtonCommand),
        typeof(ICommand),
        typeof(VowsButton));

    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
        nameof(ButtonText),
        typeof(string),
        typeof(VowsButton),
        string.Empty);

    public static readonly BindableProperty ButtonHightProperty = BindableProperty.Create(
        nameof(ButtonHight),
        typeof(double),
        typeof(VowsButton),
        57.0, 
        propertyChanged: OnEventNameChanged);


    static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
    }

    public VowsButton()
	{
		InitializeComponent();
	}

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public double ButtonHight
    {
        get => (double)GetValue(ButtonHightProperty);
        set => SetValue(ButtonHightProperty, value);
    }

    public ICommand ButtonCommand
    {
        get => (ICommand)GetValue(ButtonCommandProperty);
        set => SetValue(ButtonCommandProperty, value);
    }
}