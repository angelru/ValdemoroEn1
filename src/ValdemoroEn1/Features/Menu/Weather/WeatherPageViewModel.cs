using ValdemoroEn1.Services.API.DTO;

namespace ValdemoroEn1.Features;

public partial class WeatherPageViewModel : BaseViewModel
{
    public WeatherResponse Weather { get; set; }

    public WeatherPageViewModel()
    {
        _ = RunSafeAsync(WeatherAsync);
    }


    [RelayCommand]
    private async Task WeatherAsync()
    {
        Weather = await ApiService.WeatherAsync();
        Weather.CurrentWeather = Weather.Weather.FirstOrDefault();
    }
}
