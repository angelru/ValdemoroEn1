namespace ValdemoroEn1.Services.API.DTO;

public class AirPollutionResponse
{
    public List<AirPollution> List { get; set; }
}

public class Components
{
    public double Co { get; set; }
    public double No { get; set; }
    public double No2 { get; set; }
    public double O3 { get; set; }
    public double So2 { get; set; }
    public double Pm2_5 { get; set; }
    public double Pm10 { get; set; }
    public double Nh3 { get; set; }
}

public class AirPollution
{
    public int Dt { get; set; }
    public Airqi Main { get; set; }
    public Components Components { get; set; }
}

public class Airqi
{
    public int Aqi { get; set; }
}