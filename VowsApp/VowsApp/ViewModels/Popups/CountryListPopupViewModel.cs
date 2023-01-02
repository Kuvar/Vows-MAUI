using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowsApp.ViewModels
{
    public partial class CountryListPopupViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task ClosePopUp()
        {
            var navigationParameter = new Dictionary<string, object> { { "Bear", "animal" } };

            await Shell.Current.GoToAsync("../",true, navigationParameter);
        }
    }
}
