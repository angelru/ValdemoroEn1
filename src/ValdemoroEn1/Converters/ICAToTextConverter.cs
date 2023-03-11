using System.Globalization;

namespace ValdemoroEn1.Converters;

public class ICAToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return null;

        int ica = (int)value;
        int param = System.Convert.ToInt32((string)parameter);

        if (param is 0)
        {
            return ica switch
            {
                <= 50 => "facegreen",
                <= 100 => "faceyellow",
                <= 150 => "faceorange",
                _ => "facereed",
            };
        } 
        else
        {
            return ica switch
            {
                <= 50 => AppResources.AirGood,
                <= 100 => AppResources.AirMod,
                <= 150 => AppResources.AirUnhealthyG,
                _ => AppResources.AirUnhealthy,
            };
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
