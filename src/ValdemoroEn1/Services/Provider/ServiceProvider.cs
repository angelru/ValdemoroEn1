namespace ValdemoroEn1.Services;

public static class ServiceProvider
{
    public static TService GetService<TService>() => Current.GetService<TService>();

    public static IServiceProvider Current
        =>
#if WINDOWS10_0_17763_0_OR_GREATER
			IPlatformApplication.Current.Services;
#elif ANDROID
            IPlatformApplication.Current.Services;
#elif IOS || MACCATALYST
			IPlatformApplication.Current.Services;
#else
			null;
#endif
}