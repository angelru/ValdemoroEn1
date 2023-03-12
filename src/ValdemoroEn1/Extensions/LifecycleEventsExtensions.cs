using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Shared;

#if IOS
using Plugin.Firebase.iOS;
#endif

#if ANDROID
using Plugin.Firebase.Android;
#endif

namespace ValdemoroEn1.Extensions;

public static partial class LifecycleEventsExtensions
{
    public static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) =>
            {
                CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, state) =>
                CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
#endif
        });

        builder.Services
            .AddSingleton(_ => CrossFirebaseAuth.Current);

        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(isAuthEnabled: true,
            googleRequestIdToken: "1043453667471-h09jtasjld44dn7js3kpiq8abf5dbtcg.apps.googleusercontent.com");
    }
}