namespace ValdemoroEn1.Features;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesPageViewModel moviesPageViewModel)
	{
		InitializeComponent();
		BindingContext = moviesPageViewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var button = (Button)sender;
		string url = button.CommandParameter?.ToString();

        try
        {
            var uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }
    }
}