namespace AppUpdater.Models;

public class UpdaterVersionInfo(
    string appStoreListingUrl,
    AppVersion appStoreVersion,
    AppVersion installedVersion,
    bool isCriticalUpdate,
    AppVersion minAppVersion,
    string releaseNotes)
{
    public string AppStoreListingURL { get; init; } = appStoreListingUrl;
    public AppVersion AppStoreVersion { get; init; } = appStoreVersion;
    public AppVersion InstalledVersion { get; init; } = installedVersion;
    public bool IsCriticalUpdate { get; init; } = isCriticalUpdate;
    public AppVersion MinAppVersion { get; init; } = minAppVersion;
    public string ReleaseNotes { get; set; } = releaseNotes;

    public override string ToString()
    {
        return $"AppStoreListingURL: {AppStoreListingURL}, " +
               $"AppStoreVersion: {AppStoreVersion}, " +
               $"InstalledVersion: {InstalledVersion}, " +
               $"IsCriticalUpdate: {IsCriticalUpdate}, " +
               $"MinAppVersion: {MinAppVersion}, " +
               $"ReleaseNotes: {ReleaseNotes}";
    }
}