namespace Nik.ApiConnection;

public sealed class HttpClientFactory(ILogger<HttpClientFactory> logger) : IHttpClientFactory
{
    public HttpClient CreateClient(ApiConfigBase apiConfig)
    {
        if (string.IsNullOrWhiteSpace(apiConfig.Url))
        {
            throw new Exception("No url found to create a http client.");
        }

        logger.LogDebug($"Creating a http client to url: {apiConfig.Url}...");

        HttpClient httpClient = new();
        try
        {
            httpClient.BaseAddress = new(apiConfig.Url);
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Error creating a http client to url: {apiConfig.Url}.");
            throw;
        }

        return httpClient;
    }
}