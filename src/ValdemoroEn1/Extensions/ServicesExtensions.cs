using CommunityToolkit.Maui;

namespace ValdemoroEn1.Extensions;

public static partial class ServicesExtensions
{
    public static MauiAppBuilder RegisterPagesViewModels(this MauiAppBuilder builder)
    {
        builder.Services
        //Transient
            .AddTransientWithShellRoute<AboutPage, AboutPageViewModel>(AppSettings.About)
            .AddTransientWithShellRoute<NewsPage, NewsPageViewModel>(AppSettings.News)
            .AddTransientWithShellRoute<SchedulesRealTimePage, SchedulesRealTimePageViewModel>(AppSettings.SchedulesRealTime)
            .AddTransientWithShellRoute<InfoMenuDetailPage, InfoMenuDetailPageViewModel>(AppSettings.InfoMenuDetail)
            .AddTransientWithShellRoute<InfoMenuPage, InfoMenuPageViewModel>(AppSettings.InfoMenu)
            .AddTransientWithShellRoute<RegisterPage, RegisterPageViewModel>(AppSettings.Register)
            .AddTransientWithShellRoute<LoginPage, LoginPageViewModel>(AppSettings.Login)

        //Singleton
            .AddSingleton<TheaterPage, TheaterPageViewModel>()
            .AddSingleton<MoviesPage, MoviesPageViewModel>()
            .AddSingleton<GasStationsPage, GasStationsPageViewModel>()
            .AddSingleton<WeatherPage, WeatherPageViewModel>()
            .AddSingleton<SearchSchedulesRealTimePage, SearchSchedulesRealTimePageViewModel>()
            .AddSingleton<EstablishmentsPage, EstablishmentsPageViewModel>()
            .AddSingleton<MainPage, MainPageViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        return builder;
    }
}