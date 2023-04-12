using ValdemoroEn1.Effects;

namespace ValdemoroEn1.Extensions;

public static partial class EffectsExtenions
{
    public static MauiAppBuilder RegisterEffects(this MauiAppBuilder builder)
    {
        return builder.ConfigureEffects(effects =>
        {
            effects.Add<SearchBarTransparentEffect, SearchBarTransparentPlatformEffect>();
        });
    }
}
