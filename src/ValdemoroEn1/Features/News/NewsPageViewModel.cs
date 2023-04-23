namespace ValdemoroEn1.Features;

public partial class NewsPageViewModel : BaseViewModel, IQueryAttributable
{
    public NewsPageViewModel()
    {
    }


    [ObservableProperty]
    public NewsNotification newsNotifications;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            NewsNotifications = query["news"] as NewsNotification;
        });
    }
}
