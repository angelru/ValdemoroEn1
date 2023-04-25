using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

#if ANDROID
using Microsoft.Maui.Platform;
#endif

namespace ValdemoroEn1.Common;

public class Helper
{
    //TODO BUG: https://github.com/dotnet/maui/issues/12002
    public static void HideKeyBoard()
    {
#if ANDROID
        if (Platform.CurrentActivity.CurrentFocus != null)
        {

            Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
            Platform.CurrentActivity.CurrentFocus.ClearFocus();
        }
#endif
    }

    public static T XmlToObject<T>(string xml)
    {
        XmlDocument xmlDoc = new();
        xmlDoc.LoadXml(xml);
        xmlDoc.RemoveChild(xmlDoc.FirstChild);
        var builder = new StringBuilder();
        Newtonsoft.Json.JsonSerializer.Create().Serialize(new CustomJsonWriter(new StringWriter(builder)), xmlDoc);
        string json = builder.ToString();
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
    }

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

public class CustomJsonWriter : Newtonsoft.Json.JsonTextWriter
{
    public CustomJsonWriter(TextWriter writer) : base(writer) { }

    public override void WritePropertyName(string name)
    {
        if (name.StartsWith("@") || name.StartsWith("#"))
        {
            base.WritePropertyName(name[1..]);
        }
        else
        {
            base.WritePropertyName(name);
        }
    }
}
