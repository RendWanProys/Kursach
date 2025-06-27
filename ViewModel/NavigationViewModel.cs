using KursProjectISP31.Utills;
using System.Windows.Input;

namespace KursProjectISP31.ViewModel
{
    public class NavigationViewModel : ViewModelBase 
    {
        public ICommand HomeCommand { get; }
        public ICommand RouteSheetCommand { get; }
        public ICommand FlightDataCommand { get; }

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(); 
            }
        }

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(_ => CurrentView = new HomeViewModel());
            RouteSheetCommand = new RelayCommand(_ => CurrentView = new RouteSheetViewModel());
            FlightDataCommand = new RelayCommand(_ => CurrentView = new FlightDataViewModel());

            CurrentView = new HomeViewModel();
        }
    }
}