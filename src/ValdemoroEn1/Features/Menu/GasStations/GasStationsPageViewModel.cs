namespace ValdemoroEn1.Features;

public partial class GasStationsPageViewModel : BaseViewModel
{
    public GasStationsPageViewModel()
    {
        _ = RunSafeAsync(GasStationsAsync);
    }

    public ObservableRangeCollection<FuelResponse> Fuels { get; private set; } = new();

    [RelayCommand]
    private async Task GasStationsAsync()
    {
        var fuels = await ApiService.FuelsAsync();
        Fuels.ReplaceRange(fuels);

        //var aaa = await ApiService.GasStationsAsync();
    }
}
