using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Kozshplxapi.Tests
{
    public sealed class SimplePlexJwtAuthenticationProvider(string jwtToken, string clientIdentifier) : IAuthenticationProvider
    {
        public Task AuthenticateRequestAsync(RequestInformation request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
        {
            request.Headers.TryAdd("X-Plex-Token", jwtToken);
            request.Headers.TryAdd("X-Plex-Client-Identifier", clientIdentifier);
            request.Headers.TryAdd("X-Plex-Product", "PlexOpenApi.Tests");
            request.Headers.TryAdd("X-Plex-Version", "1.0.0");

            return Task.CompletedTask;
        }
    }
}
