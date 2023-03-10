namespace ValdemoroEn1.Models;

public class Movie
{
    public string Title { get; set; }
    public string Cover { get; set; }
    public string Synopsis { get; set; }
    public int Duration { get; set; }
    public string Gender { get; set; }
    public string Qualification { get; set; }
    public string Trailer { get; set; }
    public List<Session> Sessions { get; set; }
}

public class Session
{
    public string Hour { get; set; }
    public string Ticket { get; set; }
}

