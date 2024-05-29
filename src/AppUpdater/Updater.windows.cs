using AppUpdater.Models;

namespace AppUpdater;

partial class UpdaterImplementation : IUpdater
{
    public Task<UpdaterVersionInfo> GetVersionInfo()
    {
        throw new NotImplementedException();
    }
}