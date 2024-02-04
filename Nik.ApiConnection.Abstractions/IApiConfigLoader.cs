namespace Nik.ApiConnection.Abstractions;

public interface IApiConfigLoader
{
    ApiConfig Load(string key);
}