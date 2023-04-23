namespace ValdemoroEn1.Features;

public partial class TheaterPage : ContentPage
{
	public TheaterPage(TheaterPageViewModel theaterPageViewModel)
	{
		InitializeComponent();
		BindingContext = theaterPageViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        AppShellViewModel.Instance.InitFirebase();
    }

    private void Home_Clicked(object sender, EventArgs e)
    {
        TheaterWebView.Source = new UrlWebViewSource { Url = AppSettings.TheaterUrl };
    }
}