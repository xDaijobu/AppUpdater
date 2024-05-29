using AppUpdater.Models;

namespace AppUpdater;

internal interface IUpdater
{
    Task<UpdaterVersionInfo> GetVersionInfo(AppVersion installedVersion, string? country, string language);
}