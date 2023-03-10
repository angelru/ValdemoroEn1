namespace ValdemoroEn1.Features;

public partial class GasStationsPageViewModel : BaseViewModel
{
    public GasStationsPageViewModel()
    {
        GasStations();
    }

    public ObservableRangeCollection<FuelResponse> Fuels { get; private set; } = new();

    [RelayCommand]
    private void GasStations()
    {
        _ = RunSafeAsync(GasStationsAsync);
    }

    private async Task GasStationsAsync()
    {
        var fuels = await ApiService.FuelsAsync();
        Fuels.ReplaceRange(fuels);
        //var aaa = await ApiService.GasStationsAsync();
    }
}
