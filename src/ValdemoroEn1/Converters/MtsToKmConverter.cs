using System.Globalization;

namespace ValdemoroEn1.Converters;

public class MtsToKmConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return null;

        double mts = (double)value;
        int km = System.Convert.ToInt32(mts * 3.6);
        string final = string.Concat(km.ToString(), "km/h");
        return final;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
