namespace Nik.ApiConnection.Models;

public class ApiConfig
{
    public string Key { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public bool Cachable { get; set; } = false;

    public double CacheRetentionMinutes { get; set; } = 1;

    public EAuthenticationType AuthenticationType { get; set; } = EAuthenticationType.NoAuthentication;

    public string? Username { get; set; }

    public string? Password { get; set; }
}