namespace AppUpdater.Models;

public class UpdaterOptions()
{
    private readonly MauiAppBuilder? builder;

    internal UpdaterOptions(in MauiAppBuilder builder) : this()
    {
        this.builder = builder;
    }

    internal static string? CountryCode { get; private set; }
    internal static string? LanguageCode { get; private set; }
    internal static bool DebugDisplayAlways { get; private set; }
    internal static bool DebugDisplayOnce { get; private set; }
    internal static bool DebugLogging { get; private set; }
    internal static TimeSpan DurationUntilAlertAgain { get; private set; } = TimeSpan.FromDays(3);
    internal static AppVersion? MinAppVersion { get; private set; }

    internal static UpdaterOS UpdaterOS
    {
        get
        {
            #if ANDROID
            return UpdaterOS.Android;
#elif IOS   
            return UpdaterOS.iOS;
#elif MACCATALYST
            return UpdaterOS.MacOS;
#elif WINDOWS
            return UpdaterOS.Windows;
#endif
        }
    }
    
    internal static UpdaterVersionInfo? VersionInfo { get; private set; }
    
    /// <summary>
    /// The country code that will overrride the system locale. Optional.
    /// </summary>
    /// <param name="value"></param>
    public void SetCountryCode(string value) => CountryCode = value;
    
    /// <summary>
    /// The country code that will override the system locale. Optional. Used only for Android
    /// </summary>
    /// <param name="value"></param>
    public void SetLanguageCode(string value) => LanguageCode = value;
    
    /// <summary>
    /// For debugging, always force the upgrade to available
    /// </summary>
    /// <param name="value"></param>
    public void SetDebugDisplayAlways(bool value) => DebugDisplayAlways = value;

    /// <summary>
    /// For debugging, display the upgrade at least once once;
    /// </summary>
    /// <param name="value"></param>
    public void SetDebugDisplayOnce(bool value) => DebugDisplayOnce = value;

    /// <summary>
    /// Enable print statements for debugging.
    /// </summary>
    /// <param name="value"></param>
    public void SetDebugLogging(bool value) => DebugLogging = value;

    /// <summary>
    /// Duration until alerting user again
    /// </summary>
    /// <param name="value"></param>
    public void SetDurationUntilAlertAgain(TimeSpan value) => DurationUntilAlertAgain = value;

    /// <summary>
    /// The latest version info for this app.
    /// </summary>
    /// <param name="value"></param>
    public void SetVersionInfo(UpdaterVersionInfo value) => VersionInfo = value;
}