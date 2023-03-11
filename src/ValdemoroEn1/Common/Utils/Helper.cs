using System.Text.Json;
using System.Text.RegularExpressions;

namespace ValdemoroEn1.Common;

public class Helper
{
    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);

        return match.Success;
    }

    //The ideal is to create a database and save the stops.

    public static IEnumerable<StopName> Stops()
    {
        string json = Preferences.Get("stopNames", "default");
        if (json is "default") return new List<StopName>();

        return JsonSerializer.Deserialize<IEnumerable<StopName>>(json);
    }

    public static void SaveStops(IEnumerable<StopName> stopNames)
    {
        string json = JsonSerializer.Serialize(stopNames);
        Preferences.Set("stopNames", json);
    }

    public static Task OpenMapAsync(string name, double latitude, double longitude)
    {
        var location = new Microsoft.Maui.Devices.Sensors.Location(latitude, longitude);
        var options = new MapLaunchOptions { Name = name };

        try
        {
            return Map.Default.OpenAsync(location, options);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }

        return Task.CompletedTask;
    }

    public static async Task<bool> OpenUrlAsync(string url)
    {
        bool result = false;

        try
        {
            result = await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }

        return result;
    }
}
