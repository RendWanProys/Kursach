using KursProjectISP31.Model;
using System.Linq;
using System.Windows;

namespace KursProjectISP31.View
{
    public partial class FlightDataWindow : Window
    {
        public FlightData CurrentFlightData { get; private set; }
        private readonly KursovayaContext db = new KursovayaContext();

        public FlightDataWindow(FlightData flightData)
        {
            InitializeComponent();
            CurrentFlightData = flightData ?? new FlightData();
            DataContext = CurrentFlightData;
            FlightsComboBox.ItemsSource = db.RouteSheets.ToList();
            FlightsComboBox.SelectedValue = CurrentFlightData.FlightNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}