namespace ValdemoroEn1.Common;

public static partial class HandlersExtensions
{
    public static MauiAppBuilder RegisterHandlers(this MauiAppBuilder builder)
    {
        RegisterMappers();

        return builder.ConfigureMauiHandlers(handlers =>
        {
            // handlers here...
        });
    }

    private static void RegisterMappers()
    {
    }
}