using Newtonsoft.Json;
using ValdemoroEn1.Converters;

namespace ValdemoroEn1.Services.API.DTO;

public class MovieResponse
{
    [JsonProperty("cartelera")]
    public Cartelera Cartelera { get; set; }
}

public class Cartelera
{
    [JsonProperty("last-mod")]
    public string LastMod { get; set; }

    [JsonProperty("recinto")]
    public Recinto Recinto { get; set; }

    [JsonProperty("ProximosEventos")]
    public ProximosEventos ProximosEventos { get; set; }
}

public class Evento
{
    [JsonProperty("titulo")]
    public Titulo Titulo { get; set; }

    [JsonProperty("compra")]
    public string Compra { get; set; }

    [JsonProperty("caratula")]
    public string Caratula { get; set; }

    [JsonProperty("calificacion")]
    public string Calificacion { get; set; }

    [JsonProperty("genero")]
    public string Genero { get; set; }

    [JsonProperty("tipodecontenido")]
    public string Tipodecontenido { get; set; }

    [JsonProperty("tipodecontenidoslug")]
    public string Tipodecontenidoslug { get; set; }

    [JsonProperty("estreno")]
    public string Estreno { get; set; }

    [JsonProperty("duracion")]
    public int Duracion { get; set; }

    [JsonProperty("nacionalidad")]
    public string Nacionalidad { get; set; }

    [JsonProperty("director")]
    public string Director { get; set; }

    [JsonProperty("reparto")]
    public string Reparto { get; set; }

    [JsonProperty("distribuidora")]
    public string Distribuidora { get; set; }

    [JsonProperty("sinopsis")]
    public string Sinopsis { get; set; }

    [JsonProperty("trailer")]
    public string Trailer { get; set; }

    [JsonProperty("fechas")]
    public InfoFechas InfoFechas { get; set; }
}

public class Fecha
{
    [JsonProperty("value")]
    public string LaFecha { get; set; }

    [JsonProperty("sesiones")]
    public InfoSesiones InfoSesiones { get; set; }
}

[JsonObject("fechas")]
public class InfoFechas
{
    [JsonProperty("fecha")]
    [JsonConverter(typeof(SingleOrArrayConverterN<Fecha>))]
    public List<Fecha> Fechas { get; set; }
}

public class ProximosEventos
{
    [JsonProperty("evento")]
    [JsonConverter(typeof(SingleOrArrayConverterN<Evento>))]
    public List<Evento> Eventos { get; set; }
}

public class Recinto
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("value")]
    public string Nombre { get; set; }

    [JsonProperty("evento")]
    [JsonConverter(typeof(SingleOrArrayConverterN<Evento>))]
    public List<Evento> Eventos { get; set; }
}

public class InfoSesiones
{
    [JsonProperty("sesion")]
    [JsonConverter(typeof(SingleOrArrayConverterN<Sesion>))]
    public List<Sesion> Sesiones { get; set; }
}

public class Sesion
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("hora")]
    public string Hora { get; set; }

    [JsonProperty("aforo")]
    public string Aforo { get; set; }

    [JsonProperty("disponibles")]
    public string Disponibles { get; set; }

    [JsonProperty("numerada")]
    public string Numerada { get; set; }

    [JsonProperty("formato")]
    public string Formato { get; set; }

    [JsonProperty("sala")]
    public string Sala { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}

public class Titulo
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("nexp")]
    public string Nexp { get; set; }

    [JsonProperty("especial")]
    public string Especial { get; set; }

    [JsonProperty("text")]
    public string Nombre { get; set; }
}
