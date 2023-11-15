using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Request;
using System.Collections.ObjectModel;
using ValdemoroEn1.Common.Utils;

namespace ValdemoroEn1.Features;

public partial class InfoMenuDetailPageViewModel : BaseViewModel, IQueryAttributable
{
    private InfoMenu infoMenu;
    private PlacesDetailsResponse placesDetailsResponse;

    public InfoMenuDetailPageViewModel()
    {
    }

    public ObservableCollection<InfoMenuDetail> InfoMenuDetails { get; set; } = new();
    public ObservableCollection<ImageSource> Photos { get; set; } = new();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        infoMenu = query["infoMenu"] as InfoMenu;
        Title = infoMenu.Name;
        InfoMenuDetail();
    }

    [RelayCommand]
    private void InfoMenuDetail()
    {
        _ = RunSafeAsync(InfoMenuDetailAsync);
    }

    private async Task InfoMenuDetailAsync()
    {
        Photos.Clear();
        InfoMenuDetails.Clear();

        placesDetailsResponse = await GooglePlaces.Details.QueryAsync(new PlacesDetailsRequest
        {
            Key = AppKeys.GooglePlacesKey,
            PlaceId = infoMenu.PlaceId,
            Language = Language.Spanish,
            Fields = FieldTypes.Basic | FieldTypes.Contact
        });

        InfoMenuDetails.Add(new InfoMenuDetail
        {
            Icon = FontAwesomeIcons.Marker,
            Text = placesDetailsResponse.Result.Vicinity,
            InfoMenuDetailType = Controls.InfoMenuDetailType.Maps
        });

        InfoMenuDetails.Add(new InfoMenuDetail
        {
            Icon = FontAwesomeIcons.Phone,
            Text = placesDetailsResponse.Result.FormattedPhoneNumber ?? AppResources.WithOutTlf,
            InfoMenuDetailType = Controls.InfoMenuDetailType.Phone
        });

        InfoMenuDetails.Add(new InfoMenuDetail
        {
            Icon = FontAwesomeIcons.Globe,
            Text = placesDetailsResponse.Result.Website ?? AppResources.WithOutWeb,
            InfoMenuDetailType = Controls.InfoMenuDetailType.Web
        });

        var placeDetails = placesDetailsResponse.Result.Photos.ToList();

        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = placeDetails.Count
        };

        await Parallel.ForEachAsync(placeDetails, parallelOptions, async (ph, ct) =>
        {
            var photo = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
            {
                Key = AppKeys.GooglePlacesKey,
                PhotoReference = ph.PhotoReference,
                MaxWidth = 500,
                MaxHeight = 250
            }, ct);

            ImageSource image = ImageSource.FromStream(() => { return photo.Stream; });

            Photos.Add(image);
        });

        //Another way

        //var placesDetailsTasks = placesDetailsResponse.Result.Photos.Select(async ph =>
        //{
        //    var photo = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
        //    {
        //        Key = AppSettings.ApiKey,
        //        PhotoReference = ph.PhotoReference,
        //        MaxWidth = 500,
        //        MaxHeight = 500
        //    });

        //    ImageSource image = ImageSource.FromStream(() => { return photo.Stream; });
        //    Photos.Add(image);
        //}).ToList();

        //await Task.WhenAll(placesDetailsTasks);
    }

}
