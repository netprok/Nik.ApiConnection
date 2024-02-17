namespace Nik.ApiConnection;

public sealed class AppSettingsApiConfigLoader(
    IJsonSerializer jsonSerializer,
    IOptions<IConfigurationRoot> configuration) : IApiConfigLoader
{
    public ApiConfig Load(string key)
    {
        var apis = jsonSerializer.Deserialize<List<ApiConfig>>(configuration.Value.GetSection("apis").Value??string.Empty);

        if (apis == null )
        {
            throw new Exception("Apis section not found.");
        }

        if (!apis.Any())
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