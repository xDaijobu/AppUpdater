using AppUpdater.Models;
using HtmlAgilityPack;

namespace AppUpdater;

partial class UpdaterImplementation : IUpdater
{
    public async Task<UpdaterVersionInfo> GetVersionInfo()
    {
        //string packageName = AppInfo.Current.PackageName;
        string packageName = "com.e_intidata.MSTR_To";
        var url = $"https://play.google.com/store/apps/details?id={packageName}";

        if (!string.IsNullOrEmpty(UpdaterOptions.CountryCode))
            url += $"&hl={UpdaterOptions.LanguageCode}";

        if (!string.IsNullOrEmpty(UpdaterOptions.LanguageCode))
            url += $"&gl={UpdaterOptions.CountryCode}";

        var htmlDoc = await GetHtmlDocument(url);

        string releaseNotes = GetStoreVersion("[1][2][144][1][1]", packageName, htmlDoc);
        string latestVersion = GetStoreVersion("[1][2][140][0][0][0]", packageName, htmlDoc);
        string lastUpdated = GetStoreVersion("[1][2][145][0][0]", packageName, htmlDoc);
        string releasedDate = GetStoreVersion("[1][2][145][0][0]", packageName, htmlDoc);
        string description = GetStoreVersion("[1][2][72][0][1]", packageName, htmlDoc);

        return new UpdaterVersionInfo(url,
                                      new Version(latestVersion),
                                      AppInfo.Current.Version,
                                      UpdaterOptions.MinAppVersion,
                                      description,
                                      releasedDate,
                                      lastUpdated,
                                      releaseNotes);
    }

    private async Task<HtmlDocument> GetHtmlDocument(string url)
    {
        var htmlWeb = new HtmlWeb();
        var htmlDoc = await htmlWeb.LoadFromWebAsync(url);
        return htmlDoc;
    }

    private string GetStoreVersion(string magicNumber, string packageName, HtmlDocument htmlDoc)
    {
        try
        {
            var script = htmlDoc.DocumentNode.Descendants()
                                            .Where(n => n.Name == "script" && n.InnerText.Contains("AF_initDataCallback({key: 'ds:5'"))
                                            .FirstOrDefault()?.InnerText;
            var engine = new Jurassic.ScriptEngine();
            var eval = "(function() { var AF_initDataCallback = function(p) { return p.data" + magicNumber + "; };  return " + script + " })()";
            var result = engine.Evaluate(eval);

            return result is null ? string.Empty : result.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error parsing content from the Play Store. Error Message: " + ex.ToString(), ex);
        }
    }


}