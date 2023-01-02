using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Diagnostics;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VowsApp.Views;

namespace VowsApp.ViewModels
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isChecked;

        [ObservableProperty]
        string test;

        public SignUpPageViewModel()
        {
            IsChecked= false;
        }

        [RelayCommand]
        async Task RadioButtonTabed()
        {
            await Task.Run(() =>
            {
                isChecked = !isChecked;
                OnPropertyChanged(nameof(IsChecked));
            }); 
        }

        [RelayCommand]
        async Task NavigateToTermsofServices()
        {

        }

        [RelayCommand]
        async Task NavigateToPrivacyPolicy()
        {

        }

        [RelayCommand]
        async Task NavigateToContentPolicy()
        {

        }

        [RelayCommand]
        async Task NavigateToCreateAccount()
        {
            await Shell.Current.GoToAsync(nameof(BillSummaryPage));
        }

        [RelayCommand]
        async Task OpenCountryListPopup()
        {
            await Shell.Current.GoToAsync(nameof(CountryListPopup));
        }
    }
}
