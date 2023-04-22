namespace ValdemoroEn1.Features;

public partial class NewsPage : ContentPage
{
	public NewsPage(NewsPageViewModel newsPageViewModel)
	{
		InitializeComponent();
        BindingContext = newsPageViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}