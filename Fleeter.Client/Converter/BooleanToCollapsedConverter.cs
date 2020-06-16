using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fleeter.Client.Converter
{
    internal class BooleanToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                true => Visibility.Visible,
                false => Visibility.Collapsed,
                _ => throw new InvalidCastException()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
