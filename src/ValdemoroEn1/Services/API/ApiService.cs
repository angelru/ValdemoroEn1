using System.Net.Http.Json;

namespace ValdemoroEn1.Services;

public class ApiService
{
    private readonly HttpClient aqiCnhttpClient = new();
    private readonly HttpClient crtmHttpClient = new();

    public ApiService()
    {
        aqiCnhttpClient.BaseAddress = new Uri(AppSettings.ApiAqiCn);
        aqiCnhttpClient.Timeout = TimeSpan.FromSeconds(40);

        crtmHttpClient.BaseAddress = new Uri(AppSettings.ApiCrtm);
        crtmHttpClient.Timeout = TimeSpan.FromSeconds(40);
    }

    public async Task<object> ICAAsync()
    {
        return await aqiCnhttpClient.GetFromJsonAsync<object>("valdemoro/?token=TOKEN");
    }

    public async Task<StopTimesResponse> SchedulesAsync(string stopCode)
    {
        return await crtmHttpClient.GetFromJsonAsync<StopTimesResponse>($"GetStopsTimes.php?codStop={stopCode}&type=1&orderBy=2&stopTimesByIti=3");
    }

    public async Task<StopsResponse> StopsAsync()
    {
        return await crtmHttpClient.GetFromJsonAsync<StopsResponse>("GetStops.php?codMunicipality=4426");
    }
}

