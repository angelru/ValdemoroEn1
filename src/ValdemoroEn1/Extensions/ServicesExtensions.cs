using CommunityToolkit.Maui;

namespace ValdemoroEn1.Extensions;

public static partial class ServicesExtensions
{
    public static MauiAppBuilder RegisterPagesViewModels(this MauiAppBuilder builder)
    {
        builder.Services
        //Transient
            .AddTransientWithShellRoute<AboutPage, AboutPageViewModel>(AppSettings.About)
            .AddTransientWithShellRoute<SchedulesRealTimePage, SchedulesRealTimePageViewModel>(AppSettings.SchedulesRealTime)
            .AddTransientWithShellRoute<InfoMenuDetailPage, InfoMenuDetailPageViewModel>(AppSettings.InfoMenuDetail)
            .AddTransientWithShellRoute<InfoMenuPage, InfoMenuPageViewModel>(AppSettings.InfoMenu)

        //Singleton
            .AddSingleton<TheaterPage, TheaterPageViewModel>()
            .AddSingleton<MoviesPage, MoviesPageViewModel>()
            .AddSingleton<GasStationsPage, GasStationsPageViewModel>()
            .AddSingleton<WeatherPage, WeatherPageViewModel>()
            .AddSingleton<SearchSchedulesRealTimePage, SearchSchedulesRealTimePageViewModel>()
            .AddSingleton<EstablishmentsPage, EstablishmentsPageViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        return builder;
    }
}