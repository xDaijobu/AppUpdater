using Microsoft.Extensions.Logging;

namespace AppUpdater.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.UseUpdater((options) =>
        {
            //options.SetCountryCode("id");
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}