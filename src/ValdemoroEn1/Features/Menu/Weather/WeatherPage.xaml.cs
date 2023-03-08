namespace ValdemoroEn1.Features;

public partial class WeatherPage : ContentPage
{
	public WeatherPage(WeatherPageViewModel weatherPageViewModel)
	{
		InitializeComponent();
		BindingContext = weatherPageViewModel;
	}
}