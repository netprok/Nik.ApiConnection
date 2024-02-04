namespace Nik.ApiConnection.Models;

public sealed class BearerAuthenticationApiConfig : ApiConfigBase
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public BearerAuthenticationApiConfig()
    {
        AuthenticationType = EAuthenticationType.Bearer;
    }
}