using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace KursProjectISP31.ViewModel
{
    public class RouteSheetViewModel : ViewModelBase
    {
        private RouteSheetService routeSheetService;
        private ObservableCollection<RouteSheet> routeSheets;
        public ObservableCollection<RouteSheet> RouteSheets
        {
            get => routeSheets;
            set
            {
                if (routeSheets != value)
                {
                    routeSheets = value;
                    OnPropertyChanged(nameof(RouteSheets));
                }
            }
        }

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

        private RouteSheet selectedRouteSheet;
        public RouteSheet SelectedRouteSheet
        {
            get => selectedRouteSheet;
            set
            {
                selectedRouteSheet = value;
                OnPropertyChanged(nameof(SelectedRouteSheet));
            }
        }

        public RouteSheetViewModel()
        {
            routeSheetService = new RouteSheetService();
            RouteSheets = new ObservableCollection<RouteSheet>(routeSheetService.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ??= new RelayCommand(_ =>
        {
            var window = new RouteSheetWindow(new RouteSheet());
            if (window.ShowDialog() == true)
            {
                routeSheetService.Add(window.CurrentRouteSheet);
                RouteSheets.Add(window.CurrentRouteSheet);
            }
        });

        private RelayCommand editCommand;
        public RelayCommand EditCommand => editCommand ??= new RelayCommand(obj =>
        {
            var routeSheet = obj as RouteSheet;
            RouteSheetWindow window = new RouteSheetWindow(routeSheet);
            if (window.ShowDialog() == true)
            {
                routeSheetService.Update(window.CurrentRouteSheet);
            }
        });

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand => deleteCommand ??= new RelayCommand(obj =>
        {
            var routeSheet = obj as RouteSheet;
            var result = MessageBox.Show($"Удалить рейс {routeSheet.FlightNumber}?",
                "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                routeSheetService.Delete(routeSheet);
                RouteSheets.Remove(routeSheet);
            }
        });

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand => searchCommand ??= new RelayCommand(_ =>
        {
            RouteSheets = string.IsNullOrEmpty(SearchText)
                ? new ObservableCollection<RouteSheet>(routeSheetService.GetAll())
                : new ObservableCollection<RouteSheet>(routeSheetService.Search(SearchText));
        });
    }
}
