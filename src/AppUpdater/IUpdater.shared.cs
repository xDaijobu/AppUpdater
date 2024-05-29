using AppUpdater.Models;

namespace AppUpdater;

public interface IUpdater
{
    Task<UpdaterVersionInfo> GetVersionInfo();
}