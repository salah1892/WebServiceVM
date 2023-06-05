using WPFSignalRClient.Common;
using WPFSignalRClient.Services;
using WPFSignalRClient.SignalRService;

namespace WPFSignalRClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            Navigation.NavigateTo<PayementViewModel>();
        }
    }
}
