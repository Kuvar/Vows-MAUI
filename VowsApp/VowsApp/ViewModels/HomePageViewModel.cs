using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VowsApp.Services;

namespace VowsApp.ViewModels
{
    [QueryProperty(nameof(Placemark), "Placemark")]
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string _locationText;

        [ObservableProperty]
        public ObservableCollection<int> _listData;

        [ObservableProperty]
        public ObservableCollection<int> _listData2;

        private Placemark _placemark;

        public Placemark Placemark
        {
            get => _placemark;
            set { 
                SetProperty(ref _placemark, value); 
                LocationText = Placemark.FeatureName + ", " + Placemark.Locality;
                Preferences.Set(Constants._locationKey, LocationText);
                OnPropertyChanged(nameof(LocationText));
            }
        }


        private readonly ApiServiceHandler _apiServiceHandler;

        public HomePageViewModel(ApiServiceHandler apiServiceHandler)
        {
            IsBusy= true;
            _apiServiceHandler = apiServiceHandler;
            ListData = new ObservableCollection<int>();
            ListData2= new ObservableCollection<int>();
            Init(); 
        }

        private void Init()
        {
            for (int i = 0; i < 6; i++)
            {
                ListData.Add(i);
                ListData2.Add(i);
            }      

            LocationText = Preferences.Get(Constants._locationKey, string.Empty);
            if (string.IsNullOrEmpty(LocationText))
            {
                Task.Run(async () =>
                {
                    await LocationService.GetAddresses().ContinueWith(t =>
                    {
                        if (t.Result != null)
                        {
                            Placemark loc = t.Result.FirstOrDefault();
                            if (loc != null)
                            {
                                LocationText = loc.SubLocality + ", " + loc.Locality;
                                Preferences.Set(Constants._locationKey, LocationText);
                            }
                        }
                        IsBusy = false;
                    });
                });
            }
            else
                IsBusy = false;
        }

        [RelayCommand]
        public async Task NavigateToLocation()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SearchLocationPage());
        }
    }
}
