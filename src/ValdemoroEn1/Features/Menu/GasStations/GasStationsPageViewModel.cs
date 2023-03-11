namespace ValdemoroEn1.Features;

public partial class GasStationsPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private ListaEESSPrecio _selectedStation;

    [ObservableProperty]
    private FuelResponse _selectedFuel;

    partial void OnSelectedFuelChanged(FuelResponse value)
    {
        _ = RunSafeAsync(() => StationsAsync(value.IDProducto));
    }

    public GasStationsPageViewModel()
    {
        ShowFuels();
    }

    public ObservableRangeCollection<ListaEESSPrecio> GasStations { get; private set; } = new();
    public ObservableRangeCollection<FuelResponse> Fuels { get; private set; } = new();

    [RelayCommand]
    private async Task SelectionStationAsync()
    {
        if (SelectedStation is null) return;

        double latitude =  Convert.ToDouble(SelectedStation.Latitud);
        double longitude = Convert.ToDouble(SelectedStation.LongitudWGS84);
        await Helper.OpenMapAsync(SelectedStation.Rotulo, latitude, longitude);
        SelectedStation = null;
    }

    [RelayCommand]
    private void ShowFuels()
    {
        _ = RunSafeAsync(FuelsAsync);
    }
    private async Task StationsAsync(string iDProducto)
    {
        var gasStationResponse = await ApiService.GasStationsAsync(iDProducto);
        var stationsOrder = gasStationResponse.ListaEESSPrecio.OrderBy(o => o.PrecioProducto).ToList();
        GasStations.ReplaceRange(stationsOrder);
    }

    private async Task FuelsAsync()
    {
        var fuels = await ApiService.FuelsAsync();
        Fuels.ReplaceRange(fuels);
    }
}
