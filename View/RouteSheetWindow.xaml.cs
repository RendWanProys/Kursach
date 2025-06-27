using KursProjectISP31.Model;
using System.Windows;

namespace KursProjectISP31.View
{
    public partial class RouteSheetWindow : Window
    {
        public RouteSheet CurrentRouteSheet { get; private set; }

        public RouteSheetWindow(RouteSheet routeSheet)
        {
            InitializeComponent();
            CurrentRouteSheet = routeSheet ?? new RouteSheet();
            DataContext = CurrentRouteSheet;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}