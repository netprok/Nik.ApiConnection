namespace Nik.ApiConnection;

public sealed class ApiCacher(ILogger<ApiCacher> logger) : IApiCacher
{
    private List<ApiCache> cache = new();
    private readonly object cacheLock = new();

    public void Create(string configKey, string action, object request, object response, TimeSpan interval)
    {
        lock (cacheLock)
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

            logger.LogDebug($"Cached: ConfigKey = {configKey}, Action = {action}, Request = {request}, Response = {response}");
        }
    }

    public object? Get(string configKey, string action, object request, TimeSpan interval)
    {
        lock (cacheLock)
        {
            cache.RemoveAll(item =>
                item.ConfigKey == configKey &&
                item.Action == action &&
                item.CreateTime < DateTime.Now - interval
            );

            var cachedItem = cache.FirstOrDefault(item =>
                            item.ConfigKey == configKey &&
                            item.Action == action &&
                            item.Request == request
                        );

            logger.LogDebug($"Retrieved from cached: ConfigKey = {configKey}, Action = {action}, Request = {request}, Cached item: {cachedItem}, Response = {cachedItem?.Response}");


            return cachedItem?.Response;
        }
    }
}