namespace Nik.ApiConnection;

public sealed class AppSettingsApiConfigLoader() : IApiConfigLoader
{
    public ApiConfig Load(string key)
    {
        var apisSection = Context.Configuration.GetSection("apis");
        if (apisSection == null)
        {
            throw new Exception("Apis section not found.");
        }

        var apis = apisSection.Get<List<ApiConfig>>();
        if (apis is null || apis.Count == 0)
        {
            throw new Exception("Apis section has no data.");
        }

        var apiConfig = apis.FirstOrDefault(api => api.Key.ToLower() == key.ToLower());

        if (apiConfig == null)
        {
            throw new Exception($"Apis section ({apis.Count} items) has no item with key {key}.");
        }

        return apiConfig;
    }
}