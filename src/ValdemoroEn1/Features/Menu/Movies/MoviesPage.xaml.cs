namespace ValdemoroEn1.Features;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesPageViewModel moviesPageViewModel)
	{
		InitializeComponent();
		BindingContext = moviesPageViewModel;
	}

    private async void Hour_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string url = button.CommandParameter?.ToString(); 
        await Helper.OpenUrlAsync(url);
    }

    private async void ShowTrailer_Tapped(object sender, TappedEventArgs e)
    {
        string url = e.Parameter?.ToString();
        await Helper.OpenUrlAsync(url);
    }
}