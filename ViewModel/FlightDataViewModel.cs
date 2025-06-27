using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace KursProjectISP31.ViewModel
{
    public class FlightDataViewModel : ViewModelBase
    {
        private ObservableCollection<FlightData> flightData;
        public ObservableCollection<FlightData> FlightData
        {
            get => flightData;
            set
            {
                if (flightData != value)
                {
                    flightData = value;
                    OnPropertyChanged(nameof(FlightData));
                }
            }
        }

        public RouteSheetService routeSheetService;
        public FlightDataService flightDataService;

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public FlightDataViewModel()
        {
            routeSheetService = new RouteSheetService();
            flightDataService = new FlightDataService();
            FlightData = new ObservableCollection<FlightData>(flightDataService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ??= new RelayCommand((o) =>
        {
            var window = new FlightDataWindow(new FlightData()); 
            if (window.ShowDialog() == true)
            {
                flightDataService.Add(window.CurrentFlightData);
                FlightData.Add(window.CurrentFlightData);
            }
        });

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand => searchCommand ??= new RelayCommand((o) =>
        {
            FlightData = string.IsNullOrEmpty(SearchText)
                ? new ObservableCollection<FlightData>(flightDataService.GetAll())
                : new ObservableCollection<FlightData>(flightDataService.Search(SearchText));
        });
    }
}
