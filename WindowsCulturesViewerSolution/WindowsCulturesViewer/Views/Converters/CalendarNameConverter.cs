using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsCulturesViewer.Views.Converters
{
    public class CalendarNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;

            if (value == null)
                return string.Empty;

            if (value is Calendar calendar)
            {
                result = calendar.ToString().Remove(0, 21).Replace("Calendar", "");
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}