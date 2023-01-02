using CommunityToolkit.Mvvm.Input;
using VowsApp.Views;

namespace VowsApp.ViewModels
{
    public partial class SignInPageViewModel : BaseViewModel
    {
        public SignInPageViewModel()
        {

        }

        [RelayCommand]
        async Task NavigateToLogin()
        {
            await Task.Run(() =>
            {

            });
        }

        [RelayCommand]
        async Task NavigateToSignUp()
        {
            //await Shell.Current.GoToAsync(nameof(SignUpPage));
            //await Shell.Current.GoToAsync(nameof(SelectServiceListPage));
            //await Shell.Current.GoToAsync(nameof(HomePage));
            Application.Current.MainPage = new AppShell();
        }
    }
}
