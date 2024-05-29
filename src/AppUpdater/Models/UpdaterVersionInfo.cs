using Microsoft.Maui.ApplicationModel;

namespace AppUpdater.Models;

public class UpdaterVersionInfo(
    string appStoreListingUrl,
    Version? appStoreVersion,
    Version installedVersion,
    Version? minAppVersion,
    string? description,
    string? releaseDate,
    string? lastUpdated,
    string? releaseNotes)
{
    public string AppStoreListingURL { get; init; } = appStoreListingUrl;
    public Version? AppStoreVersion { get; init; } = appStoreVersion;
    public Version InstalledVersion { get; init; } = installedVersion;
    public Version? MinAppVersion { get; init; } = minAppVersion;
    public string? Description { get; init; } = description;
    public string? ReleaseDate { get; init; } = releaseDate;
    public string? LastUpdated { get; init; } = lastUpdated;
    public string? ReleaseNotes { get; set; } = releaseNotes;

    public override string ToString()
    {
        return $"AppStoreListingURL: {AppStoreListingURL}, " +
               $"AppStoreVersion: {AppStoreVersion}, " +
               $"InstalledVersion: {InstalledVersion}, " +
               $"MinAppVersion: {MinAppVersion}, " +
               $"Description: {Description}, " +
               $"LastUpdated: {LastUpdated}, " +
               $"ReleaseDate: {ReleaseDate}, " +
               $"ReleaseNotes: {ReleaseNotes}";
    }
}