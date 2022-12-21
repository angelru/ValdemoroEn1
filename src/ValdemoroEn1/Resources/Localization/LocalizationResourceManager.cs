using System.ComponentModel;
using System.Globalization;

namespace ValdemoroEn1.Resources.Localization;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    private LocalizationResourceManager()
    {
        string language = Preferences.Get("language", "default");
        if (language is "default")
        {
            SetCulture(CultureInfo.CurrentCulture);
        }
        else
        {
            SetCulture(new CultureInfo(language));
        }
    }

    public static LocalizationResourceManager Instance { get; } = new();

    public object this[string resourceKey] =>
        AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();

    public event PropertyChangedEventHandler PropertyChanged;

    public void SetCulture(CultureInfo culture)
    {
        AppResources.Culture = culture;
        Preferences.Set("language", culture.Name);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}