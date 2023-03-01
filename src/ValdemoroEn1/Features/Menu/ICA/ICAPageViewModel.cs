namespace ValdemoroEn1.Features;

public class ICAPageViewModel : BaseViewModel
{
    public ICAPageViewModel()
    {
        ICAWeather();
    }

    private void ICAWeather()
    {
        _ = RunSafeAsync(ICAWeatherAsync);
    }

    private async Task ICAWeatherAsync()
    {
        var asas = await ApiService.ICAAsync();
    }
}
