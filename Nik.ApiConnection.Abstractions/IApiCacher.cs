namespace Nik.ApiConnection.Abstractions;

public interface IApiCacher
{
    void Create(string configKey, string action, object request, HttpResponseMessage response, TimeSpan interval);

    HttpResponseMessage? Get(string configKey, string action, object request, TimeSpan interval);
}