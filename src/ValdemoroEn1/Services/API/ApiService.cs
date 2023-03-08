using System.Net.Http.Json;
using ValdemoroEn1.Services.API.DTO;

namespace ValdemoroEn1.Services;

public class ApiService
{
    private readonly HttpClient openWeatherhttpClient = new();
    private readonly HttpClient crtmHttpClient = new();

    public ApiService()
    {
        openWeatherhttpClient.BaseAddress = new Uri(AppSettings.ApiOpenWeather);
        openWeatherhttpClient.Timeout = TimeSpan.FromSeconds(40);

        crtmHttpClient.BaseAddress = new Uri(AppSettings.ApiCrtm);
        crtmHttpClient.Timeout = TimeSpan.FromSeconds(40);
    }

    public Task<object> ICAAsync(long latitute, long longitude)
    {
        return openWeatherhttpClient.GetFromJsonAsync<object>($"air_pollution?lat={latitute}&lon={longitude}&appid={AppSettings.ApiOpenWeatherKey}&lang=es");
    }

    public Task<WeatherResponse> WeatherAsync()
    {
        return openWeatherhttpClient.GetFromJsonAsync<WeatherResponse>($"weather?id=3106868&appid={AppSettings.ApiOpenWeatherKey}&lang=es&units=metric");
    }

    public Task<StopTimesResponse> SchedulesAsync(string stopCode)
    {
        return crtmHttpClient.GetFromJsonAsync<StopTimesResponse>($"GetStopsTimes.php?codStop={stopCode}&type=1&orderBy=2&stopTimesByIti=3");
    }

    public Task<StopsResponse> StopsAsync()
    {
        return crtmHttpClient.GetFromJsonAsync<StopsResponse>("GetStops.php?codMunicipality=4426");
    }
}

