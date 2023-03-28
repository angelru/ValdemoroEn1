﻿using Microsoft.Maui.LifecycleEvents;

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
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize();
                FirebaseAuthImplementation.Initialize();
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity)));
                FirebaseAuthImplementation.Initialize("1043453667471-h09jtasjld44dn7js3kpiq8abf5dbtcg.apps.googleusercontent.com");
#endif
        });

        builder.Services
            .AddSingleton(_ => CrossFirebaseAuth.Current);

        return builder;
    }
}