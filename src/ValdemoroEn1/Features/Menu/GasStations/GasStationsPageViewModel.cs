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
        double lat =  Convert.ToDouble(SelectedStation.Latitud);
        double longi = Convert.ToDouble(SelectedStation.LongitudWGS84);

        var location = new Microsoft.Maui.Devices.Sensors.Location(lat, longi);
        var options = new MapLaunchOptions { Name = SelectedStation.Rotulo };

        try
        {
            await Map.Default.OpenAsync(location, options);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }

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
