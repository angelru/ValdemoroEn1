namespace ValdemoroEn1.Controls;

//TODO BUG: https://github.com/dotnet/maui/issues/14058
public class IssueiOSTemplateSelector : DataTemplateSelector
{
    public DataTemplate AndroidTemplate { get; set; }
    public DataTemplate IoSTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (IsAndroid())
        {
            return AndroidTemplate;
        }

        return IoSTemplate;
    }

    private static bool IsAndroid() => DeviceInfo.Current.Platform == DevicePlatform.Android;
}
