namespace ValdemoroEn1.Features;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesPageViewModel moviesPageViewModel)
	{
		InitializeComponent();
		BindingContext = moviesPageViewModel;
	}

    public async void OpenUrl_Tapped(object sender, TappedEventArgs e)
    {
        string url = e.Parameter?.ToString();
        await Helper.OpenUrlAsync(url);
    }
}