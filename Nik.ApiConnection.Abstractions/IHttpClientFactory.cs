namespace Nik.ApiConnection.Abstractions;

public interface IHttpClientFactory
{
    HttpClient CreateClient(ApiConfig apiConfig);
}