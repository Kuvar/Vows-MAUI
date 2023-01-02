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
    public partial class AddressBookPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<AddressModel> _addresses;

        public AddressBookPageViewModel()
        {
            Addresses= new ObservableCollection<AddressModel>();

            _= InitData();
        }

        [RelayCommand]
        public async Task EditAddress(AddressModel address)
        {

        }

        [RelayCommand]
        public async Task DeleteAddress(AddressModel address)
        {

        }

        private async Task InitData()
        {
            await Task.Run(() => {
                for (int i = 1; i <= 4; i++)
                {
                    Addresses.Add(new AddressModel { Id = 1, Address = "Address - " + i, ContactNumber = "123456789" + i, Name = "Name " + i });
                }
            });
        }
    }
}
