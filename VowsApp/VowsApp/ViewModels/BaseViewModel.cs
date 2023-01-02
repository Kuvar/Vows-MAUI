using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowsApp.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
