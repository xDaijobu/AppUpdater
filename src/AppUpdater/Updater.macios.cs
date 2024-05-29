using AppUpdater.Models;
using Foundation;
using System.Text.Json.Nodes;

namespace AppUpdater;

partial class UpdaterImplementation : IUpdater
{
    record Response(int SchemaVersion, string Label, string Message, string Color);
    record AppiOS(string Version, string Url, string ReleaseNotes, string ReleaseDate, string LastUpdated, string Description);

    private string _bundleIdentifier => NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleIdentifier").ToString();
    private string countryCode => "us";

    public async Task<UpdaterVersionInfo> GetVersionInfo()
    {
        string bundleId = _bundleIdentifier ;
        string url = $"https://itunes.apple.com/lookup?id={bundleId}&country={UpdaterOptions.CountryCode ?? countryCode}";
        var app = await LookupApp(bundleId, url);

        return new UpdaterVersionInfo(app.Url,
                                      string.IsNullOrEmpty(app?.Version) ? null : new Version(app.Version),
                                      AppInfo.Current.Version,
                                      UpdaterOptions.MinAppVersion,
                                      app.Description,
                                      app.ReleaseDate,
                                      app.LastUpdated,
                                      app.ReleaseNotes);
    }

    private async Task<AppiOS?> LookupApp(string bundleId, string url)
    {
        try
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(url);
            var content = response.Content == null ? null : await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                return null;

            var appLookup = JsonValue.Parse(content);

            return new AppiOS(appLookup["results"][0]["version"].ToString(),
                              appLookup["results"][0]["trackViewUrl"].ToString(),
                              appLookup["results"][0]["releaseNotes"].ToString(),
                              appLookup["results"][0]["releaseDate"].ToString(),
                              appLookup["results"][0]["currentVersionReleaseDate"].ToString(),
                              appLookup["results"][0]["description"].ToString());
        }
        catch (Exception e)
        {
            throw new Exception($"Error looking up app details in App Store. BundleIdentifier={bundleId}.", e);
        }
    }
}