namespace Nik.ApiConnection;

public sealed class ApiCacher : IApiCacher
{
    private List<ApiCache> cache = new();

    public void Create(string configKey, string action, object request, object response, TimeSpan interval)
    {
        cache.RemoveAll(item =>
            item.ConfigKey == configKey &&
            item.Action == action &&
            item.Request == request
        );

        cache.Add(new()
        {
            ConfigKey = configKey,
            Action = action,
            Request = request,
            Response = response
        });
    }

    public object? Get(string configKey, string action, object request, TimeSpan interval)
    {
        cache.RemoveAll(item =>
            item.ConfigKey == configKey &&
            item.Action == action &&
            item.CreateTime < DateTime.Now - interval
        );

        return cache.FirstOrDefault(item =>
            item.ConfigKey == configKey &&
            item.Action == action &&
            item.Request == request
        )?.Response;
    }
}