namespace Nik.ApiConnection.Models;

public class ApiConfigBase
{
    public string Key { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public EAuthenticationType AuthenticationType { get; set; } = EAuthenticationType.NoAuthentication;

    public bool Cachable { get; set; } = false;

    public double CacheRetentionMinutes { get; set; } = 1;
}