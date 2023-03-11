using System.Text.Json.Serialization;

namespace ValdemoroEn1.Services.API.DTO;

public class GasStationResponse
{
    [JsonPropertyName("Fecha")]
    public string Fecha { get; set; }

    [JsonPropertyName("ListaEESSPrecio")]
    public List<ListaEESSPrecio> ListaEESSPrecio { get; set; }

    [JsonPropertyName("Nota")]
    public string Nota { get; set; }

    [JsonPropertyName("ResultadoConsulta")]
    public string ResultadoConsulta { get; set; }
}

public class ListaEESSPrecio
{
    [JsonPropertyName("C.P.")]
    public string CP { get; set; }

    [JsonPropertyName("Dirección")]
    public string Direccion { get; set; }

    [JsonPropertyName("Horario")]
    public string Horario { get; set; }

    [JsonPropertyName("Latitud")]
    public string Latitud { get; set; }

    [JsonPropertyName("Localidad")]
    public string Localidad { get; set; }

    [JsonPropertyName("Longitud (WGS84)")]
    public string LongitudWGS84 { get; set; }

    [JsonPropertyName("Margen")]
    public string Margen { get; set; }

    [JsonPropertyName("Municipio")]
    public string Municipio { get; set; }

    [JsonPropertyName("PrecioProducto")]
    public string PrecioProducto { get; set; }

    [JsonPropertyName("Provincia")]
    public string Provincia { get; set; }

    [JsonPropertyName("Remisión")]
    public string Remision { get; set; }

    [JsonPropertyName("Rótulo")]
    public string Rotulo { get; set; }

    [JsonPropertyName("Tipo Venta")]
    public string TipoVenta { get; set; }

    [JsonPropertyName("IDEESS")]
    public string IDEESS { get; set; }

    [JsonPropertyName("IDMunicipio")]
    public string IDMunicipio { get; set; }

    [JsonPropertyName("IDProvincia")]
    public string IDProvincia { get; set; }

    [JsonPropertyName("IDCCAA")]
    public string IDCCAA { get; set; }
}

