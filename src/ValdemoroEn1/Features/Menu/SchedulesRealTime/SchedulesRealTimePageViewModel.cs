namespace ValdemoroEn1.Features;

public partial class SchedulesRealTimePageViewModel : BaseViewModel, IQueryAttributable
{
    private string stopCode = string.Empty;

    public SchedulesRealTimePageViewModel()
    {

    }

    public ObservableRangeCollection<StopTimesGroup> StopTimesGroups { get; set; } = new();

    public StopTimesResponse StopTimesResponse { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        stopCode = query["stopCode"] as string;
        Schedules();
    }

    [RelayCommand]
    private void Schedules()
    {
        _ = RunSafeAsync(SchedulesAsync, stateError: StateKey.CrtmError);
    }

    private async Task SchedulesAsync()
    {
        StopTimesResponse = await ApiService.SchedulesAsync(stopCode);
        var times = StopTimesResponse.StopTimes.Times.Time;

        if (times is null) return;

        var stopTimeGroups = FlattenTimes(times);

        StopTimesGroups.ReplaceRange(stopTimeGroups);
    }

    private List<StopTimesGroup> FlattenTimes(List<TimeStop> times)
    {
        var stopTimeGroups = times.GroupBy(g => g.Line.ShortDescription).Select(grp =>
        {
            var timesGrp = grp.ToList().OrderBy(m => m.StopTime);
            var line = timesGrp.First().Line;

            var stopTimeNames = timesGrp.GroupBy(g => g.Destination).Select(grp => new StopTimeName
            {
                Name = grp.First().Destination,
                Times = grp.Select(time =>
                {
                    var timeSpam = time.StopTime - DateTime.Now;
                    int minutes = (int)timeSpam.TotalMinutes;

                    if (minutes >= 0 && minutes <= 59)
                    {
                        return timeSpam.TotalMinutes.ToString();
                    }

                    return time.StopTime.ToShortTimeString();

                }).ToList()
            }).ToList();

            var stopTimesGroup = new StopTimesGroup(line.Description.Split("-", 2).Last(), line.CodMode, line.ShortDescription, stopTimeNames);
            return stopTimesGroup;
        }).ToList();

        return stopTimeGroups;
    }
}