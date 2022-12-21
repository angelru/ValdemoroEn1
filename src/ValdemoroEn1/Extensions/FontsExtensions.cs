namespace ValdemoroEn1.Extensions;

public static partial class FontsExtensions
{
    public static MauiAppBuilder RegisterFonts(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("FontAwesomeBrands.otf", "FontAwesomeBrands");
            fonts.AddFont("FontAwesomeRegular.otf", "FontAwesomeRegular");
            fonts.AddFont("FontAwesomeSolid.otf", "FontAwesomeSolid");
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
    }
}
