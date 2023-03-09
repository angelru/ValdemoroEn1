namespace ValdemoroEn1.Services.API.DTO;

public class StopsResponse
{
    public Stops Stops { get; set; }
}

public class CodLines
{
    public object Line { get; set; }
}

public class Coordinates
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}

public class StopMunicipality
{
    public string CodStop { get; set; }
    public string ShortCodStop { get; set; }
    public string CodMode { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string CodMunicipality { get; set; }
    public Coordinates Coordinates { get; set; }
    public CodLines CodLines { get; set; }
    public int Access { get; set; }
    public int Aark { get; set; }
    public int NightLinesService { get; set; }
    public int StopType { get; set; }
}

public class Stops
{
    public List<StopMunicipality> Stop { get; set; }
}
