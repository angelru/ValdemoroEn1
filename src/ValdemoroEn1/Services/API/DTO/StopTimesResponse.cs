using System.Text.Json.Serialization;
using ValdemoroEn1.Converters;

namespace ValdemoroEn1.Services;

public class StopTimesResponse
{
    public StopTimes StopTimes { get; set; }
}

public class Line
{
    public string CodLine { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string CodMode { get; set; }
}

public class Stop
{
    public string CodStop { get; set; }
    public string ShortCodStop { get; set; }
    public string Name { get; set; }
}

public class StopTimes
{
    public Stop Stop { get; set; }
    public Times Times { get; set; }
}

public class TimeStop
{
    public Line Line { get; set; }
    public string Destination { get; set; }

    [JsonPropertyName("time")]
    public DateTime StopTime { get; set; }
}

public class Times
{
    [JsonConverter(typeof(SingleOrArrayConverter<TimeStop>))]
    public List<TimeStop> Time { get; set; }
}