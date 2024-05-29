using AppUpdater.Models;

namespace AppUpdater;

internal partial class UpdaterImplementation : IUpdater
{
    public async Task<UpdaterVersionInfo> GetVersionInfo(AppVersion installedVersion, string? country, string language)
    {
        
    }
}