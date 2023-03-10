namespace ValdemoroEn1.Features;

public partial class WeatherPageViewModel : BaseViewModel
{
    public WeatherPageViewModel()
    {
        ShowWeather();
    }

    public WeatherResponse Weather { get; set; }

    [RelayCommand]
    private void ShowWeather()
    {
        _ = RunSafeAsync(WeatherAsync);
    }

    private async Task WeatherAsync()
    {
        Weather = await ApiService.WeatherAsync();
    }
}
