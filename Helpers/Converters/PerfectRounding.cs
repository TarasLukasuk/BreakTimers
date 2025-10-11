using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BreakTimers.Helpers.Converters
{
    public class PerfectRoundingConverter : IValueConverter
    {
        const int DIVIDE = 2;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double doubleValue)
            {
                throw new ArgumentException($"Value must be a {typeof(double).Name}.");
            }

            if (doubleValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");
            }

            if (targetType != typeof(CornerRadius))
            {
                throw new ArgumentException($"Target type must be {typeof(CornerRadius).Name}.");
            }

            if (parameter is not null)
            {
                throw new ArgumentException("No parameter is expected.");
            }

            if (culture is not null)
            {
                throw new ArgumentException("No culture is expected.");
            }


            return new CornerRadius(doubleValue / DIVIDE);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
