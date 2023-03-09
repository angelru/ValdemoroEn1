namespace ValdemoroEn1.Services.API.DTO;

public class WeatherResponse
{
    public string Status { get; set; }
    public IQAir Data { get; set; }
}

public class Current
{
    public Pollution Pollution { get; set; }
    public Weather Weather { get; set; }
}

public class IQAir
{
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public Location Location { get; set; }
    public Current Current { get; set; }
}

public class Location
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}

public class Pollution
{
    public DateTime Ts { get; set; }
    public int Aqius { get; set; }
    public string Mainus { get; set; }
    public int Aqicn { get; set; }
    public string Maincn { get; set; }
}

public class Weather
{
    public DateTime Ts { get; set; }
    public double Tp { get; set; }
    public double Pr { get; set; }
    public double Hu { get; set; }
    public double Ws { get; set; }
    public double Wd { get; set; }
    public string Ic { get; set; }
}
