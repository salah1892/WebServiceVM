using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSignalRClient.Common;
using WPFSignalRClient.Services;

namespace WPFSignalRClient.ViewModel
{
    public class OtherViewModel : ViewModelBase
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
        public RelayCommand goToPayement { get; set; }
        public OtherViewModel(INavigationService navigationService)
        {
            _navigation = navigationService;
            goToPayement= new RelayCommand(o => { Navigation.NavigateTo<PayementViewModel>(); }, o => true);
        }
    }
}
