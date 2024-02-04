namespace Nik.ApiConnection.Abstractions;

public interface IApiCacher
{
    object? Get(string configKey, string action, object request, TimeSpan interval);

    void Create(string configKey, string action, object request, object response, TimeSpan interval);
}