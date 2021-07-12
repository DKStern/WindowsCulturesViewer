using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsCulturesViewer.Views.Converters
{
    public class AdditionalCalendarNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string result = string.Empty;

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