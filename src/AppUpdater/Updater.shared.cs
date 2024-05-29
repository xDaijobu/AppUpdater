namespace AppUpdater;

public static class Updater
{
    static IUpdater? defaultImplementation;

    public static IUpdater Current => defaultImplementation ??= new UpdaterImplementation();

    internal static void SetDefault(IUpdater? implementation) =>
        defaultImplementation = implementation;
}