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
}
