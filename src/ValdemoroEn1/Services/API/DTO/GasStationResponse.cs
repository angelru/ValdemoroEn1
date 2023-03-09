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
    public string Direccin { get; set; }

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

    [JsonPropertyName("Precio Biodiesel")]
    public string PrecioBiodiesel { get; set; }

    [JsonPropertyName("Precio Bioetanol")]
    public string PrecioBioetanol { get; set; }

    [JsonPropertyName("Precio Gas Natural Comprimido")]
    public string PrecioGasNaturalComprimido { get; set; }

    [JsonPropertyName("Precio Gas Natural Licuado")]
    public string PrecioGasNaturalLicuado { get; set; }

    [JsonPropertyName("Precio Gases licuados del petróleo")]
    public string PrecioGasesLicuadosDelPetrleo { get; set; }

    [JsonPropertyName("Precio Gasoleo A")]
    public string PrecioGasoleoA { get; set; }

    [JsonPropertyName("Precio Gasoleo B")]
    public string PrecioGasoleoB { get; set; }

    [JsonPropertyName("Precio Gasoleo Premium")]
    public string PrecioGasoleoPremium { get; set; }

    [JsonPropertyName("Precio Gasolina 95 E10")]
    public string PrecioGasolina95E10 { get; set; }

    [JsonPropertyName("Precio Gasolina 95 E5")]
    public string PrecioGasolina95E5 { get; set; }

    [JsonPropertyName("Precio Gasolina 95 E5 Premium")]
    public string PrecioGasolina95E5Premium { get; set; }

    [JsonPropertyName("Precio Gasolina 98 E10")]
    public string PrecioGasolina98E10 { get; set; }

    [JsonPropertyName("Precio Gasolina 98 E5")]
    public string PrecioGasolina98E5 { get; set; }

    [JsonPropertyName("Precio Hidrogeno")]
    public string PrecioHidrogeno { get; set; }

    [JsonPropertyName("Provincia")]
    public string Provincia { get; set; }

    [JsonPropertyName("Remisión")]
    public string Remisin { get; set; }

    [JsonPropertyName("Rótulo")]
    public string Rtulo { get; set; }

    [JsonPropertyName("Tipo Venta")]
    public string TipoVenta { get; set; }

    [JsonPropertyName("% BioEtanol")]
    public string BioEtanol { get; set; }

    [JsonPropertyName("% Éster metílico")]
    public string sterMetlico { get; set; }

    [JsonPropertyName("IDEESS")]
    public string IDEESS { get; set; }

    [JsonPropertyName("IDMunicipio")]
    public string IDMunicipio { get; set; }

    [JsonPropertyName("IDProvincia")]
    public string IDProvincia { get; set; }

    [JsonPropertyName("IDCCAA")]
    public string IDCCAA { get; set; }
}

