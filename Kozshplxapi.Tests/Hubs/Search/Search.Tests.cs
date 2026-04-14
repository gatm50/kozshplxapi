using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Kozshplxapi.Tests.Hubs.Search
{
    public class Search(TestConfigFixture cfg) : IClassFixture<TestConfigFixture>
    {
        private readonly TestConfigFixture _cfg = cfg ?? throw new ArgumentNullException(nameof(cfg));

        private ApiClient CreateClient()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new SimplePlexJwtAuthenticationProvider(_cfg.PlexJwtToken, _cfg.PlexClientIdentifier));
            requestAdapter.BaseUrl = _cfg.PlexBaseUrl;
            return new ApiClient(requestAdapter);
        }

        [Theory]
        [InlineData(4, "Alice in the Jungle")]
        [InlineData(4, "What's Up Doc?")]
        [InlineData(4, "The Ant from Uncle")]
        [InlineData(4, "8 Ball Bunny")]
        public async Task SearchContent_WithSectionAndTitle_ReturnsResponse(int sectionId, string title)
        {
            var apiClient = CreateClient();

            var searchResult = await apiClient.Hubs.Search.GetAsync(s =>
            {
                s.QueryParameters.SectionId = sectionId;
                s.QueryParameters.Query = title;
            }, TestContext.Current.CancellationToken);

            Assert.NotNull(searchResult);
            Assert.NotNull(searchResult!.MediaContainer);
        }
    }
}
