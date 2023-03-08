﻿namespace ValdemoroEn1.Extensions;

public static partial class ServicesExtensions
{
    public static MauiAppBuilder RegisterPagesViewModels(this MauiAppBuilder builder)
    {
        builder.Services
        //Transient
            .AddTransient<WeatherPage>().AddTransient<WeatherPageViewModel>()
            .AddTransient<SchedulesRealTimePage>().AddTransient<SchedulesRealTimePageViewModel>()
            .AddTransient<InfoMenuDetailPage>().AddTransient<InfoMenuDetailPageViewModel>()
            .AddTransient<InfoMenuPage>().AddTransient<InfoMenuPageViewModel>()
            .AddTransient<RegisterPage>().AddTransient<RegisterPageViewModel>()
            .AddTransient<LoginPage>().AddTransient<LoginPageViewModel>()

        //Singleton
            .AddSingleton<SearchSchedulesRealTimePage>().AddSingleton<SearchSchedulesRealTimePageViewModel>()
            .AddSingleton<MainPage>().AddSingleton<MainPageViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        return builder;
    }
}