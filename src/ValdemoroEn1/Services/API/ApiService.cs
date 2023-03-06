using System.Net.Http.Json;

namespace ValdemoroEn1.Services;

public class ApiService
{
    private readonly HttpClient openWheaterhttpClient = new();
    private readonly HttpClient crtmHttpClient = new();

    public ApiService()
    {
        openWheaterhttpClient.BaseAddress = new Uri(AppSettings.ApiOpenWheater);
        openWheaterhttpClient.Timeout = TimeSpan.FromSeconds(40);

        crtmHttpClient.BaseAddress = new Uri(AppSettings.ApiCrtm);
        crtmHttpClient.Timeout = TimeSpan.FromSeconds(40);
    }

    public Task<object> ICAAsync()
    {
        return openWheaterhttpClient.GetFromJsonAsync<object>("valdemoro/?token=TOKEN");
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

