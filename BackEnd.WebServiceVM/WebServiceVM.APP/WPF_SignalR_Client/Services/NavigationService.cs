using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSignalRClient.Common;

namespace WPFSignalRClient.Services
{
    public class NavigationService : ViewModelBase, INavigationService
    {

        public ViewModelBase? _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        // private INavigationService _navigationServiceImplementation;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }


        public void NavigateTo<TViewModelBase>() where TViewModelBase : ViewModelBase
        {

            ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModelBase));
            CurrentView = viewModel;
        }
    }
}
