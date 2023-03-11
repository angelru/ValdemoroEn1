namespace ValdemoroEn1.Features;

public partial class GasStationsPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private FuelResponse _selectedFuel;

    partial void OnSelectedFuelChanged(FuelResponse value)
    {
        _ = RunSafeAsync(() => StationsAsync(value.IDProducto));
    }

    private async Task StationsAsync(string iDProducto)
    {
        var asa = await ApiService.GasStationsAsync(iDProducto);
    }

    public GasStationsPageViewModel()
    {
        ShowFuels();
    }

    public ObservableRangeCollection<FuelResponse> Fuels { get; private set; } = new();

    [RelayCommand]
    private void ShowFuels()
    {
        _ = RunSafeAsync(FuelsAsync);
    }

    private async Task FuelsAsync()
    {
        var fuels = await ApiService.FuelsAsync();
        Fuels.ReplaceRange(fuels);
    }
}
