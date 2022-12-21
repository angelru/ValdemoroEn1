namespace ValdemoroEn1.Extensions;

public static partial class ServicesExtensions
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        //Transient
        builder.Services.AddTransient<SchedulesRealTimePageViewModel>();
        builder.Services.AddTransient<SchedulesRealTimePage>();

        builder.Services.AddTransient<InfoMenuDetailPageViewModel>();
        builder.Services.AddTransient<InfoMenuDetailPage>();

        builder.Services.AddTransient<InfoMenuPageViewModel>();
        builder.Services.AddTransient<InfoMenuPage>();

        builder.Services.AddTransient<RegisterPageViewModel>();
        builder.Services.AddTransient<RegisterPage>();

        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<LoginPage>();

        //Singleton
        builder.Services.AddSingleton<SearchSchedulesRealTimePageViewModel>();
        builder.Services.AddSingleton<SearchSchedulesRealTimePage>();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);

        return builder;
    }
}
