namespace Nik.ApiConnection.UnitTests;

public class ApiConfigLoadUnitTest
{
    private static IHost PrepareHost()
    {
        return Host.CreateDefaultBuilder()
           .ConfigureServices((services) =>
           {
               services.InitContext()
                   .AddNikSerialization()
                   .AddNikApiConnection();
           })
           .Build();
    }

    [Fact]
    public void TestApiConfigLoad()
    {
        var host = PrepareHost();

        var loader = host.Services.GetService<IApiConfigLoader>();
        Models.ApiConfig apiConfig = loader.Load("TestApi");
        apiConfig.Key.Should().Be("TestApi");
        apiConfig.Url.Should().Be("http://localhost:1111/api/v1/");
    }
}