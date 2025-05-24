using System;
using System.Globalization;

namespace AppReports.Converters;

public class OptionToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
       return value?.ToString() == parameter?.ToString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((bool)value) return parameter?.ToString();
        return null;
    }
}
