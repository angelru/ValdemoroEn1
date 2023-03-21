namespace ValdemoroEn1.Features;

public partial class TheaterPage : ContentPage
{
	public TheaterPage(TheaterPageViewModel theaterPageViewModel)
	{
		InitializeComponent();
		BindingContext = theaterPageViewModel;
	}

    private void Home_Clicked(object sender, EventArgs e)
    {
        TheaterWebView.Source = new UrlWebViewSource { Url = AppSettings.TheaterUrl };
    }

    private void GoBack_Clicked(object sender, EventArgs e)
    {
        TheaterWebView.GoBack();
    }
}