namespace ValdemoroEn1.Controls;

public partial class InfoMenuDetailView : ContentView
{
    public static readonly BindableProperty InfoMenuDetailTypeProperty = BindableProperty.Create(nameof(InfoMenuDetailType), typeof(InfoMenuDetailType), typeof(InfoMenuDetailView), InfoMenuDetailType.None, BindingMode.TwoWay, propertyChanged: InfoItemDetailTypeChanged);
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(InfoMenuDetailView), default(string));
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(InfoMenuDetailView), default(string));

    public InfoMenuDetailType InfoMenuDetailType
    {
        get => (InfoMenuDetailType)GetValue(InfoMenuDetailTypeProperty);
        set => SetValue(InfoMenuDetailTypeProperty, value);
    }

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private static void InfoItemDetailTypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var nfoItemView = bindable as InfoMenuDetailView;
        nfoItemView.SetInfoItemType();
    }

    private void SetInfoItemType()
    {
        switch (InfoMenuDetailType)
        {
            case InfoMenuDetailType.None:
                InfoMenuDetailType = InfoMenuDetailType.None;
                break;
            case InfoMenuDetailType.Phone:
                InfoMenuDetailType = InfoMenuDetailType.Phone;
                AddGesture(() => OpenTlfAsync(Text));
                break;
            case InfoMenuDetailType.Web:
                InfoMenuDetailType = InfoMenuDetailType.Web;
                AddGesture(() => OpenUrlAsync(Text));
                break;
            case InfoMenuDetailType.Maps:
                InfoMenuDetailType = InfoMenuDetailType.Maps;
                AddGesture(() => OpenMapAsync(Text));
                break;
            default:
                InfoMenuDetailType = InfoMenuDetailType.None;
                break;
        }
    }

    private async Task OpenMapAsync(string text)
    {
        var placemark = new Placemark
        {
            CountryName = null,
            AdminArea = null,
            Thoroughfare = text,
            Locality = null,
        };

        await Map.OpenAsync(placemark);
    }

    private async Task OpenUrlAsync(string text)
    {
        if (text.Contains("http"))
        {
            await Helper.OpenUrlAsync(text);
        }
    }

    private Task OpenTlfAsync(string text)
    {
        if (PhoneDialer.Default.IsSupported)
            PhoneDialer.Default.Open(text);

        return Task.CompletedTask;
    }

    private void AddGesture(Func<Task> action)
    {
        GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(async () => await action()),
            NumberOfTapsRequired = 1
        });
    }

    public InfoMenuDetailView()
    {
        InitializeComponent();
    }
}

public enum InfoMenuDetailType
{
    None,
    Phone,
    Web,
    Maps
}