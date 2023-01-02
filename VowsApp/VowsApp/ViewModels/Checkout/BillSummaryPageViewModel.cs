using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VowsApp.Views;

namespace VowsApp.ViewModels
{
    public partial class BillSummaryPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<string> _quickSearch;
        
        [ObservableProperty]
        ObservableCollection<int> _services;

        public BillSummaryPageViewModel()
        {
            Services = new ObservableCollection<int>();
            QuickSearch = new ObservableCollection<string>();
            _ = InitData();           
        }

        private async Task InitData()
        {
            await Task.Run(() =>
            {
                QuickSearch.Add("Women’s spa");
                QuickSearch.Add("Sofa cleaning");
                QuickSearch.Add("Room cleaning");

                for (int i = 0; i < 5; i++)
                {
                    Services.Add(i);
                }
            });
        }


        [RelayCommand]
        public async Task WhatsIncluded(int id)
        {
            await Shell.Current.GoToAsync(nameof(WhatsIncludedPopup));
        }
    }
}
