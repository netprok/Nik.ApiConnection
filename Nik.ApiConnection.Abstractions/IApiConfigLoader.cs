namespace Nik.ApiConnection.Abstractions;

public interface IApiConfigLoader
{
    ApiConfigBase Load(string key);
}