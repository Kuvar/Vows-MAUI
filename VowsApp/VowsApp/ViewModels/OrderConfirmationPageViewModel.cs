using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowsApp.ViewModels
{
    public partial class OrderConfirmationPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<int> _orders;

        public OrderConfirmationPageViewModel()
        {
            Orders = new ObservableCollection<int>();
            _ = InitData();
        }

        private async Task InitData()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Orders.Add(i);
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
