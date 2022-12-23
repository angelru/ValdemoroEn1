using System.Net.Http.Json;

namespace ValdemoroEn1.Services;

public class ApiService
{
    private readonly HttpClient httpClient = new();

    public ApiService()
    {
        httpClient.BaseAddress = new Uri(AppSettings.ApiCrtm);
        httpClient.Timeout = TimeSpan.FromSeconds(40);
    }

    public async Task<StopTimesResponse> SchedulesAsync(string stopCode)
    {
        return await httpClient.GetFromJsonAsync<StopTimesResponse>($"GetStopsTimes.php?codStop={stopCode}&type=1&orderBy=2&stopTimesByIti=3");
    }

    public async Task<StopsResponse> StopsAsync()
    {
        return await httpClient.GetFromJsonAsync<StopsResponse>("GetStops.php?codMunicipality=4426");
    }
    
}

