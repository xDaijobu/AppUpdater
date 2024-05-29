namespace AppUpdater;

internal static class Updater
{
    private static IUpdater? defaultImplementation;

    public static IUpdater Default => defaultImplementation ??= new UpdaterImplementation();

    internal static void SetDefault(IUpdater? implementation) => 
        defaultImplementation = implementation;
}