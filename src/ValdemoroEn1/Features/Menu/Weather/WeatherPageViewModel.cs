namespace ValdemoroEn1.Features;

public partial class WeatherPageViewModel : BaseViewModel
{
    public WeatherPageViewModel()
    {
        _ = RunSafeAsync(WeatherAsync);
    }

    public WeatherResponse Weather { get; set; }

    [RelayCommand]
    private async Task WeatherAsync()
    {
        Weather = await ApiService.WeatherAsync();
    }
}
