using CommunityToolkit.Mvvm.Messaging;
using ValdemoroEn1.Services.API.DTO;

namespace ValdemoroEn1.ViewModels;

public partial class SearchSchedulesRealTimePageViewModel : BaseViewModel, IRecipient<StopName>
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
        WeakReferenceMessenger.Default.Register(this);
        StopsMunicipality();
    }

    [RelayCommand]
    private void StopsMunicipality()
    {
        _ = RunSafeAsync(StopsMunicipalityAsync, stateError: StateKey.CrtmError);
    }

    public ObservableRangeCollection<StopName> StopMunicipalities { get; set; } = new();
    public ObservableRangeCollection<StopName> StopNames { get; set; } = new();

    [RelayCommand]
    private void SearchStop()
    {
        var stopNames = stopMunicipalities.Where(w => w.CodStop.Contains(TextStopCode.ToUpper()) || w.Name.Contains(TextStopCode.ToUpper())).Select(s => new StopName(s.CodStop, s.ShortCodStop, s.Name)).ToList();
        StopMunicipalities.ReplaceRange(stopNames);
    }

    private async Task StopsMunicipalityAsync()
    {
        var stopsMunicipality = await ApiService.StopsAsync();
        stopMunicipalities = stopsMunicipality.Stops.Stop;
        StopNames.ReplaceRange(Helper.Stops());
    }

    [RelayCommand]
    private void DeleteStopName(StopName stopName)
    {
        StopNames.Remove(stopName);
        Helper.SaveStops(StopNames);
    }

    [RelayCommand]
    private async Task SchedulesAsync(string stopCode)
    {
        NavigationService.AddParameter("stopCode", stopCode);
        await NavigationService.NavigationAsync("schedulesrealtime");
    }

    public void Receive(StopName stopName)
    {
        var stop = StopNames.FirstOrDefault(f => f.StopCode == stopName.StopCode);

        if (stop is null)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StopNames.Add(stopName);
            });

            Helper.SaveStops(StopNames);
        }
    }
}
