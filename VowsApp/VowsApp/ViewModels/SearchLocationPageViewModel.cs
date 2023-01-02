using CommunityToolkit.Mvvm.ComponentModel;
using VowsApp.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace VowsApp.ViewModels
{
    public partial class SearchLocationPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Placemark> _placemarks;

        private string _location;

        public string LocationText
        {
            get { return _location; }
            set
            {
                _location = value;
                TextChangedCommand.Execute(_location);
                OnPropertyChanged();
            }
        }

        public Command TextChangedCommand => new Command<string>(async (_location) => await TextChanged(_location));

        public SearchLocationPageViewModel()
        {
            LocationText = Preferences.Get(Constants._locationKey, string.Empty);
        }

        private async Task TextChanged(string address)
        {
            if (IsBusy)
                return;
            
            IsBusy = true;
            await LocationService.GetLocations(address).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    Placemarks = new ObservableCollection<Placemark>(t.Result);
                }
                IsBusy= false;
            });
        }

        [RelayCommand]
        Task AddressSelected(Placemark placemark) => 
            Shell.Current.GoToAsync($"{nameof(HomePage)}",
            new Dictionary<string, object>
            {
                ["Placemark"] = placemark
            });
    }
}
