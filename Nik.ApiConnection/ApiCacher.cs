namespace Nik.ApiConnection;

public sealed class ApiCacher(
    IJsonSerializer jsonSerializer,
    ILogger<ApiCacher> logger) : IApiCacher
{
    private List<ApiCache> _cache = new();
    private readonly object _cacheLock = new();

    public void Create(string configKey, string action, object request, HttpResponseMessage response, TimeSpan interval)
    {
        lock (_cacheLock)
        {
            var serializedRequest = jsonSerializer.Serialize(request, false);

            _cache.RemoveAll(item =>
                item.ConfigKey == configKey &&
                item.Action == action &&
                item.Request == serializedRequest
            );

            _cache.Add(new()
            {
                ConfigKey = configKey,
                Action = action,
                Request = serializedRequest,
                Response = response
            });

            logger.LogDebug($"Cached a new item: ConfigKey = {configKey}, Action = {action}, Request = {serializedRequest}");
        }
    }

    public HttpResponseMessage? Get(string configKey, string action, object request, TimeSpan interval)
    {
        lock (_cacheLock)
        {
            var serializedRequest = jsonSerializer.Serialize(request, false);

            _cache.RemoveAll(item =>
                item.ConfigKey == configKey &&
                item.Action == action &&
                item.CreateTime < DateTime.Now - interval
            );

            var cachedItem = _cache.FirstOrDefault(item =>
                            item.ConfigKey == configKey &&
                            item.Action == action &&
                            item.Request == serializedRequest
                        );

            if (cachedItem is null)
            {
                logger.LogDebug($"No cached item for: ConfigKey = {configKey}, Action = {action}, Request = {serializedRequest}");
            }

            return cachedItem?.Response;
        }
    }
}