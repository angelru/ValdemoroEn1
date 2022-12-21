namespace ValdemoroEn1.Models;

public class StopTimesGroup
{
    public StopTimesGroup()
    {
    }

    public StopTimesGroup(string name, string codMode, string line, List<StopTimeName> stopTimeNames)
    {
        Name = name;
        CodMode = codMode;
        Line = line;
        StopTimeNames = stopTimeNames;
    }

    public string Name { get; set; }
    public string CodMode { get; set; }
    public string Line { get; set; }
    public List<StopTimeName> StopTimeNames { get; set; } = new();
}

public class StopTimeName
{
    public string Name { get; set; }
    public List<string> Times { get; set; } = new();
}
