using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.CloudMessaging;

#if ANDROID
using Plugin.Firebase.Core.Platforms.Android;
#else
using Plugin.Firebase.Core.Platforms.iOS;
#endif

namespace ValdemoroEn1.Extensions;

public static partial class LifecycleEventsExtensions
{
    public static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if IOS
            events.AddiOS(iOS => iOS.WillFinishLaunching((app, launchOptions) => {
                CrossFirebase.Initialize();
                FirebaseCloudMessagingImplementation.Initialize();
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity)));
#endif
        });

        builder.Services
            .AddSingleton(_ => CrossFirebaseCloudMessaging.Current);

        return builder;
    }
}