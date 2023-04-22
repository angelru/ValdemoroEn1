namespace ValdemoroEn1.Features;

public partial class NewsPageViewModel : BaseViewModel, IQueryAttributable
{
    public NewsPageViewModel()
    {
    }


    [ObservableProperty]
    public NewsNotification newsNotification;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        NewsNotification = query["news"] as NewsNotification;
    }
}
