using System.Xml.Serialization;

namespace ValdemoroEn1.Services.API.DTO;

[XmlRoot(ElementName = "cartelera")]
public class MovieResponse
{
    [XmlElement(ElementName = "recinto")]
    public Recinto Recinto { get; set; }
    [XmlElement(ElementName = "ProximosEventos")]
    public ProximosEventos ProximosEventos { get; set; }
    [XmlAttribute(AttributeName = "last-mod")]
    public string LastMod { get; set; }
}

[XmlRoot(ElementName = "titulo")]
public class Titulo
{
    [XmlText]
    public string Nombre { get; set; }
    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "nexp")]
    public int Nexp { get; set; }

    [XmlAttribute(AttributeName = "especial")]
    public int Especial { get; set; }
}

[XmlRoot(ElementName = "sesion")]
public class Sesion
{

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "hora")]
    public string Hora { get; set; }

    [XmlAttribute(AttributeName = "aforo")]
    public int Aforo { get; set; }

    [XmlAttribute(AttributeName = "disponibles")]
    public int Disponibles { get; set; }

    [XmlAttribute(AttributeName = "numerada")]
    public int Numerada { get; set; }

    [XmlAttribute(AttributeName = "formato")]
    public string Formato { get; set; }

    [XmlAttribute(AttributeName = "sala")]
    public int Sala { get; set; }

    [XmlAttribute(AttributeName = "url")]
    public string Url { get; set; }
}

[XmlRoot(ElementName = "sesiones")]
public class InfoSesiones
{

    [XmlElement(ElementName = "sesion")]
    public List<Sesion> Sesiones { get; set; }
}

[XmlRoot(ElementName = "fecha")]
public class Fecha
{

    [XmlElement(ElementName = "sesiones")]
    public InfoSesiones InfoSesiones { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string LaFecha { get; set; }
}

[XmlRoot(ElementName = "fechas")]
public class InfoFechas
{

    [XmlElement(ElementName = "fecha")]
    public List<Fecha> Fechas { get; set; }
}

[XmlRoot(ElementName = "evento")]
public class Evento
{
    [XmlElement(ElementName = "titulo")]
    public Titulo Titulo { get; set; }

    [XmlElement(ElementName = "compra")]
    public string Compra { get; set; }

    [XmlElement(ElementName = "caratula")]
    public string Caratula { get; set; }

    [XmlElement(ElementName = "calificacion")]
    public string Calificacion { get; set; }

    [XmlElement(ElementName = "genero")]
    public string Genero { get; set; }

    [XmlElement(ElementName = "tipodecontenido")]
    public string Tipodecontenido { get; set; }

    [XmlElement(ElementName = "tipodecontenidoslug")]
    public string Tipodecontenidoslug { get; set; }

    [XmlElement(ElementName = "estreno")]
    public string Estreno { get; set; }

    [XmlElement(ElementName = "duracion")]
    public int Duracion { get; set; }

    [XmlElement(ElementName = "nacionalidad")]
    public string Nacionalidad { get; set; }

    [XmlElement(ElementName = "director")]
    public string Director { get; set; }

    [XmlElement(ElementName = "reparto")]
    public string Reparto { get; set; }

    [XmlElement(ElementName = "distribuidora")]
    public string Distribuidora { get; set; }

    [XmlElement(ElementName = "sinopsis")]
    public string Sinopsis { get; set; }

    [XmlElement(ElementName = "trailer")]
    public string Trailer { get; set; }

    [XmlElement(ElementName = "fechas")]
    public InfoFechas InfoFechas { get; set; }
}


[XmlRoot(ElementName = "recinto")]
public class Recinto
{
    [XmlElement(ElementName = "evento")]
    public List<Evento> Eventos { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Nombre { get; set; }
}

[XmlRoot(ElementName = "ProximosEventos")]
public class ProximosEventos
{
    [XmlElement(ElementName = "evento")]
    public List<Evento> Eventos { get; set; }
}
