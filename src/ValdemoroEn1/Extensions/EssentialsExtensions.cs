namespace ValdemoroEn1.Extensions;

public static partial class EssentialsExtensions
{
    public static MauiAppBuilder RegisterEssentials(this MauiAppBuilder builder)
    {
        return builder.ConfigureEssentials(essentials =>
        {
            essentials.UseVersionTracking();
        });
    }
}
