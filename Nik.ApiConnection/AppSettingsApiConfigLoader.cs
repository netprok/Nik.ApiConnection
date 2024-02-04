namespace Nik.ApiConnection;

public sealed class AppSettingsApiConfigLoader(IOptions<List<ApiConfigBase>> Apis) : IApiConfigLoader
{
    public ApiConfigBase Load(string key)
    {
        if (Apis == null || Apis.Value == null)
        {
            throw new Exception("Apis section not found.");
        }

        if (!Apis.Value.Any())
        {
            throw new Exception("Apis section has no data.");
        }

        var apiConfig = Apis.Value.FirstOrDefault(api => api.Key.ToLower() == key.ToLower());

        if (apiConfig == null)
        {
            throw new Exception($"Apis section ({Apis.Value.Count} items) has no item with key {key}.");
        }

        return apiConfig;
    }
}