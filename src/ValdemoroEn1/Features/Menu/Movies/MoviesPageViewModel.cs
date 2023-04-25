namespace ValdemoroEn1.Features;

public partial class MoviesPageViewModel : BaseViewModel
{
    private readonly List<Evento> events = new();

    [ObservableProperty]
    private MovieDate _selectedDate;

    partial void OnSelectedDateChanged(MovieDate value)
    {
        _ = RunSafeAsync(async () =>
        {
            var movies = FlattenMovies(value.Date);
            await Task.Yield();
            Movies.ReplaceRange(movies);
        });
    }

    public MoviesPageViewModel()
    {
        ShowMovies();
    }

    public ObservableRangeCollection<Movie> Movies { get; private set; } = new();

    public ObservableRangeCollection<MovieDate> Dates { get; private set; } = new();

    public string Name { get; private set; }

    [RelayCommand]
    private void ShowMovies()
    {
        _ = RunSafeAsync(MoviesAsync);
    }

    private async Task MoviesAsync()
    {
        var movie = await ApiService.MovieTimesAsync();
        Name = movie.Cartelera.Recinto.Nombre;

        events.AddRange(movie.Cartelera.Recinto.Eventos);
        events.AddRange(movie.Cartelera.ProximosEventos.Eventos);

        var dates = GetDates();
        Dates.ReplaceRange(dates);
    }

    private List<Movie> FlattenMovies(string date)
    {
        var eventsDate = events.Where(s => s.InfoFechas != null && s.InfoFechas.Fechas.Any(s => s.LaFecha == date)).ToList();

        if (eventsDate.Any())
        {
            var movies = eventsDate.Select(evento =>
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

        return new List<Movie>();
    }

    private List<MovieDate> GetDates()
    {
        var dates = new List<MovieDate>();

        for (int i = 0; i < 7; i++)
        {
            var movieDate = new MovieDate
            {
                Date = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"),
                DisplayDate = DateTime.Now.AddDays(i).ToString("dddd, d MMMM")
            };

            dates.Add(movieDate);
        }

        return dates;
    }
}
