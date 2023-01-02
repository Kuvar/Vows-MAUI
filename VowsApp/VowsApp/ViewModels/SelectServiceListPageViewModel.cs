using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace VowsApp.ViewModels
{
    public partial class SelectServiceListPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<string> _quickSearch;

        [ObservableProperty]
        ObservableCollection<int> _services;

        public SelectServiceListPageViewModel()
        {
            _ = InitData();
        }

        private async Task InitData()
        {
            await Task.Run(() =>
            {
                QuickSearch = new ObservableCollection<string>
                {
                    new string("Women’s spa"),
                    new string("Sofa cleaning"),
                    new string("Room cleaning"),
                };

                Services = new ObservableCollection<int>();
                for (int i = 0; i < 10; i++)
                {
                    Services.Add(i);
                }
            });
        }

        [RelayCommand]
        public async Task WhatsIncluded(int id)
        {
            await Task.Run(async () =>
            {
                await Shell.Current.GoToAsync(nameof(WhatsIncludedPopup));
            });     
        }
    }
}
