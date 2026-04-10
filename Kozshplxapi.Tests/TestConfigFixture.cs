
using Microsoft.Extensions.Configuration;

namespace Kozshplxapi.Tests
{
    public sealed class TestConfigFixture
    {
        public IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json", optional: false)
            .AddUserSecrets("65b13470-4d86-4ed4-879e-100cf778f1cb")
            .AddEnvironmentVariables()
            .Build();

        public string PlexJwtToken => Configuration["Plex:JwtToken"]!;
        public string PlexClientIdentifier => Configuration["Plex:ClientIdentifier"]!;
        public string PlexBaseUrl => Configuration["Plex:BaseUrl"]!;
    }
}