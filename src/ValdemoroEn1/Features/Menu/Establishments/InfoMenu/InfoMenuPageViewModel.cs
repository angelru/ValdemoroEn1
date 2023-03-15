using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;

namespace ValdemoroEn1.Features;

public partial class InfoMenuPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private InfoMenu _selectedInfoMenu;

    [ObservableProperty]
    private bool _loadMore;

    [ObservableProperty]
    private int _itemTreshold;

    private PlacesTextSearchRequest placesTextSearchRequest = null;
    private readonly string[] postalCode = new string[] { "28340", "28341", "28342", "28343" };

    public InfoMenuPageViewModel()
    {
    }

    public ObservableRangeCollection<InfoMenu> InfoMenus { get; set; } = new();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        string title = query["title"] as string;
        Title = title;

        InfoMenu();
    }

    [RelayCommand]
    private void InfoMenu()
    {
        ItemTreshold = 5;
        _ = RunSafeAsync(() => SearchTextQueryAsync(Title));
    }

    private async Task SearchTextQueryAsync(string query)
    {
        placesTextSearchRequest = new PlacesTextSearchRequest
        {
            Key = AppSettings.ApiKey,
            Query = string.Format("{0} {1}", query, AppSettings.CityQuery),
            Language = Language.Spanish
        };

        var placesTextSearchResponse = await GooglePlaces.Search.TextSearch.QueryAsync(placesTextSearchRequest);
        placesTextSearchRequest.PageToken = placesTextSearchResponse.NextPageToken;

        var infoMenus = await InfoQueryAsync(placesTextSearchResponse.Results);

        InfoMenus.ReplaceRange(infoMenus);
    }

    [RelayCommand]
    private async Task SelectionInfoMenuAsync()
    {
        if (SelectedInfoMenu is null) return;
        NavigationService.AddParameter("infoMenu", SelectedInfoMenu);
        await NavigationService.NavigationAsync("infomenudetails");
        SelectedInfoMenu = null;
    }

    [RelayCommand]
    private async Task LoadMoreInfoItemsAsync()
    {
        await RunSafeAsync(LoadMoreAsync, false);
    }

    private async Task LoadMoreAsync()
    {
        if (LoadMore) return;

        if (placesTextSearchRequest.PageToken is null)
        {
            ItemTreshold = -1;
        }
        else
        {
            LoadMore = true;

            await Task.Delay(1000);
            var placesTextSearchResponse = await GooglePlaces.Search.TextSearch.QueryAsync(placesTextSearchRequest);
            placesTextSearchRequest.PageToken = placesTextSearchResponse.NextPageToken;

            var infoMenus = await InfoQueryAsync(placesTextSearchResponse.Results);

            LoadMore = false;

            InfoMenus.AddRange(infoMenus);
        }
    }

    private async Task<List<InfoMenu>> InfoQueryAsync(IEnumerable<TextResult> results)
    {
        List<InfoMenu> infoMenus = new();

        var cleanResults = results.Where(result => result.Photos != null && postalCode.Any(result.FormattedAddress.Contains)).ToList();

        if (cleanResults.Any())
        {
            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = cleanResults.Count
            };

            await Parallel.ForEachAsync(cleanResults, parallelOptions, async (search, ct) =>
            {
                var photo = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
                {
                    Key = AppSettings.ApiKey,
                    PhotoReference = search.Photos.Select(s => s.PhotoReference).FirstOrDefault(),
                    MaxWidth = 250,
                    MaxHeight = 250
                }, ct);

                infoMenus.Add(new InfoMenu
                {
                    PlaceId = search.PlaceId,
                    Photo = ImageSource.FromStream(() => { return photo.Stream; }),
                    Name = search.Name
                });
            });
        }

        return infoMenus;

        //Another way

        //var taskResults = results.Where(result => result.Photos != null
        //&& postalCode.Any(result.FormattedAddress.Contains)).Select(async search =>
        //{
        //   var photo = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
        //   {
        //       Key = AppSettings.ApiKey,
        //       PhotoReference = search.Photos.ToList().Select(s => s.PhotoReference).FirstOrDefault(),
        //       MaxWidth = 150,
        //       MaxHeight = 150,
        //   });

        //   infoItems.Add(new InfoItem
        //   {
        //       PlaceId = search.PlaceId,
        //       Photo = ImageSource.FromStream(() => { return photo.Stream; }),
        //       Name = search.Name
        //   });
        //}).ToList();

        //await Task.WhenAll(taskResults);
    }
}