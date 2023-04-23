namespace ValdemoroEn1.Features;

public partial class NewsPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private NewsNotification _newsNotifications;

    public NewsPageViewModel()
    {
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        NewsNotifications = query["news"] as NewsNotification;
    }
}