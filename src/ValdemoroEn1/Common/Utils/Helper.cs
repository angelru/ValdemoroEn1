using System.Text.Json;

namespace ValdemoroEn1.Common;

public class Helper
{
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
}
