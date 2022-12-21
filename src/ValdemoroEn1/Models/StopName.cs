namespace ValdemoroEn1.Models;

public class StopName
{
    public StopName(string stopCode, string shortStopCode, string name)
    {
        StopCode = stopCode;
        ShortStopCode = shortStopCode;
        Name = name;
    }

    public string StopCode { get; set; }
    public string ShortStopCode { get; set; }
    public string Name { get; set; }
}
