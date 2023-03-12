using System.Globalization;

namespace ValdemoroEn1.Converters;

public class TextToIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return null;

        string text = (string)value;
        string last = text[^1..];
        string finalText = string.Concat(last, text);
        return finalText;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
