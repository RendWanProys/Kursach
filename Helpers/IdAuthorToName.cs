using KursProjectISP31.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace KursProjectISP31.Helpers
{
    public class FlightNumberToInfo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;

            var flightNumber = value.ToString();
            using var db = new KursovayaContext();
            var route = db.RouteSheets
                .FirstOrDefault(r => r.FlightNumber == flightNumber);

            return route != null
                ? $"{route.FlightNumber} ({route.DriverName})"
                : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}