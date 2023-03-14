namespace ValdemoroEn1.Features;

public partial class SearchSchedulesRealTimePageViewModel : BaseViewModel
{
    private List<StopMunicipality> stopMunicipalities = new();

    [ObservableProperty]
    private string _textStopCode;

    partial void OnTextStopCodeChanged(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            StopMunicipalities.Clear();
        }
    }

    public SearchSchedulesRealTimePageViewModel()
    {
        StopsMunicipality();
    }

    public ObservableRangeCollection<StopName> StopMunicipalities { get; set; } = new();
    public ObservableRangeCollection<StopName> StopNames { get; set; } = new();

    [RelayCommand]
    private void StopsMunicipality()
    {
        _ = RunSafeAsync(StopsMunicipalityAsync, stateError: StateKey.CrtmError);
    }

    private async Task StopsMunicipalityAsync()
    {
        var stopsMunicipality = await ApiService.StopsAsync();
        stopMunicipalities = stopsMunicipality.Stops.Stop;
        StopNames.ReplaceRange(Helper.Stops());
    }

    [RelayCommand]
    private void SearchStop()
    {
        var stopNames = stopMunicipalities.Where(w => w.CodStop.Contains(TextStopCode.ToUpper()) || w.Name.Contains(TextStopCode.ToUpper())).Select(s => new StopName(s.CodStop, s.ShortCodStop, s.Name)).ToList();
        StopMunicipalities.ReplaceRange(stopNames);
    }

    [RelayCommand]
    private void DeleteStopName(StopName stopName)
    {
        StopNames.Remove(stopName);
        Helper.SaveStops(StopNames);
    }

    [RelayCommand]
    private async Task SchedulesAsync(StopName stopName)
    {
        AddStopName(stopName);
        NavigationService.AddParameter("stopCode", stopName.StopCode);
        await NavigationService.NavigationAsync("schedulesrealtime");
    }

    private void AddStopName(StopName stopName)
    {
        var stop = StopNames.FirstOrDefault(f => f.StopCode == stopName.StopCode);

        if (stop is null)
        {
            StopNames.Add(stopName);
            Helper.SaveStops(StopNames);
        }
    }
}
