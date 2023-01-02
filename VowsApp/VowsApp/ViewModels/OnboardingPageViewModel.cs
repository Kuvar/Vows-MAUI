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
    public partial class OnboardingPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<OnboardingModels> _onboardingList;

        [ObservableProperty]
        public int _position;

        [ObservableProperty]
        public bool _showSkipButton;

        public OnboardingPageViewModel()
        {
            ShowSkipButton= false;
            OnboardingList = new ObservableCollection<OnboardingModels>();
            InitilizeOnboardingList();
            Position=0;

            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += (s, e) => ShowSkipButton = true;
            timer.Start();
        }

        private void InitilizeOnboardingList()
        {
            OnboardingList.Add( new OnboardingModels 
            { 
                Id= 1,
                Image_url = "onboarding_first.svg",
                Title= "Find your Comfort Food here",
                Sub_title= "Here You Can find a chef or dish for every taste and color. Enjoy!"
            });
            OnboardingList.Add(new OnboardingModels
            {
                Id = 2,
                Image_url = "onboarding_second.svg",
                Title = "Food Ninja is Where Your Comfort Food Lives",
                Sub_title = "Enjoy a fast and smooth food delivery at your doorstep"
            });
        }

        [RelayCommand]
        public async Task Skip()
        {
            await Shell.Current.GoToAsync(nameof(SignInPage));
        }
    }
}
