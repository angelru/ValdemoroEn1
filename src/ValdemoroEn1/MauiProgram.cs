using CommunityToolkit.Maui;
using ValdemoroEn1.Extensions;

namespace ValdemoroEn1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .RegisterFonts()
            .RegisterServices()
            .RegisterFirebaseServices()
            .RegisterPagesViewModels()
            .RegisterEffects()
            .RegisterHandlers()
            .UseMauiCommunityToolkit();

        return builder.Build();
    }
}