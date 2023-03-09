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
            if (ica <= 50)
            {
                return "facegreen";
            }
            else if (ica <= 100)
            {
                return "faceyellow";
            }
            else if (ica <= 150)
            {
                return "faceorange";
            }

            return "facereed";
        } 
        else
        {
            if (ica <= 50)
            {
                return AppResources.AirGood;
            }
            else if (ica <= 100)
            {
                return AppResources.AirMod;
            }
            else if (ica <= 150)
            {
                return AppResources.AirUnhealthyG;
            }

            return AppResources.AirUnhealthy;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
