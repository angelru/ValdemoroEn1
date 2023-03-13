namespace ValdemoroEn1.Features;

public partial class MoviesPageViewModel : BaseViewModel
{
    private List<Evento> Events = new();

    [ObservableProperty]
    private string _selectedDate;

    partial void OnSelectedDateChanged(string value)
    {
        string date = value;
        var movies = FlattenMovies(date);
        Movies.ReplaceRange(movies);
    }

    public MoviesPageViewModel()
    {
        ShowMovies();
    }

    public ObservableRangeCollection<Movie> Movies { get; private set; } = new();
    public ObservableRangeCollection<string> Dates { get; private set; } = new();
    public string Name { get; private set; }

    [RelayCommand]
    private void ShowMovies()
    {
        _ = RunSafeAsync(MoviesAsync);
    }
    private async Task MoviesAsync()
    {
        var movie = await ApiService.MovieTimesAsync();
        Name = movie.Recinto.Nombre;
        Events = movie.Recinto.Eventos;

        var dates = FlattenDates(Events);
        Dates.ReplaceRange(dates);
    }
    private List<Movie> FlattenMovies(string date)
    {
        var movies = Events.Where(s => s.InfoFechas.Fechas.Any(s => s.LaFecha == date))
             .Select(evento =>
             {
                 var sessions = evento.InfoFechas.Fechas.FirstOrDefault(s => s.LaFecha == date)
                                      .InfoSesiones.Sesiones.Select(s =>
                                            new Session
                                            {
                                                Hour = s.Hora,
                                                Ticket = s.Url
                                            }).ToList();

                 var movie = new Movie
                 {
                     Title = evento.Titulo.Nombre,
                     Cover = evento.Caratula,
                     Synopsis = evento.Sinopsis,
                     Duration = evento.Duracion,
                     Gender = evento.Genero,
                     Qualification = evento.Calificacion,
                     Trailer = evento.Trailer,
                     Sessions = sessions
                 };

                 return movie;
             }).ToList();

        return movies;
    }
    private List<string> FlattenDates(List<Evento> events)
    {
        var dates = events.Select(s => s.InfoFechas.Fechas.GroupBy(g => g.LaFecha)
                          .Select(s => s.FirstOrDefault().LaFecha)).FirstOrDefault().ToList();
        return dates;
    }
}
