using System.Collections.ObjectModel;

namespace ValdemoroEn1.Features;

public partial class EstablishmentsPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private InfoItem _selectedInfoItem;

    public EstablishmentsPageViewModel()
    {
    }

    public ObservableCollection<InfoItem> Establishments { get; set; } =
        new ObservableCollection<InfoItem>
    {
        new InfoItem(FontAwesomeIcons.Utensils, AppResources.FoodDelivery),
        new InfoItem(FontAwesomeIcons.Utensils, AppResources.Restaurants),
        new InfoItem(FontAwesomeIcons.Hotel, AppResources.Hostels)
    };

    [RelayCommand]
    private async Task SelectionInfoItemAsync()
    {
        if (SelectedInfoItem is null) return;

    }
}
