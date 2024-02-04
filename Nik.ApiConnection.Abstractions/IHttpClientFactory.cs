namespace Nik.ApiConnection.Abstractions;

public interface IHttpClientFactory
{
    HttpClient CreateClient(ApiConfigBase apiConfigBase);
}