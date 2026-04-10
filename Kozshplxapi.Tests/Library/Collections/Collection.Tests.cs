using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Kozshplxapi.Tests.Library.Collections
{
    public class Collection(TestConfigFixture cfg) : IClassFixture<TestConfigFixture>
    {
        private readonly TestConfigFixture _cfg = cfg ?? throw new ArgumentNullException(nameof(cfg));

        private ApiClient CreateClient()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new SimplePlexJwtAuthenticationProvider(_cfg.PlexJwtToken, _cfg.PlexClientIdentifier));
            requestAdapter.BaseUrl = _cfg.PlexBaseUrl;
            return new ApiClient(requestAdapter);
        }

        [Fact]
        public async Task UpdateCollection_WithJwtAuth_Returns200Ok()
        {
            var client = CreateClient();

            await client.Library.Collections[14343].PutAsync(4, requestConfiguration =>
            {
                requestConfiguration.QueryParameters.TypeId = 18;
                requestConfiguration.QueryParameters.Title = "Sample Test";
                requestConfiguration.QueryParameters.TitleLocked = 0;
                requestConfiguration.QueryParameters.TitleSort = "Bugs Bunny ++";
                requestConfiguration.QueryParameters.TitleSortLocked = 1;
                requestConfiguration.QueryParameters.Summary = "Updated summary for testing. Unlocked, plain 200OK";
                requestConfiguration.QueryParameters.SummaryLocked = 0;
                requestConfiguration.QueryParameters.ContentRatingValue = "PG";
                requestConfiguration.QueryParameters.ContentRatingLocked = 0;
            }, TestContext.Current.CancellationToken);
        }

        [Fact]
        public void ToPutRequestInformation_BuildsExpectedEndpointAndQuery()
        {
            var client = CreateClient();

            var requestInfo = client.Library.Collections[14343].ToPutRequestInformation(4, requestConfiguration =>
            {
                requestConfiguration.QueryParameters.TypeId = 18;
                requestConfiguration.QueryParameters.Summary = "Collection for all Bugs Bunny Cartoons";
                requestConfiguration.QueryParameters.SummaryLocked = 1;
            });

            var uriProperty = requestInfo.GetType().GetProperty("URI") ?? requestInfo.GetType().GetProperty("Uri");
            Assert.NotNull(uriProperty);

            var uri = uriProperty!.GetValue(requestInfo) as Uri;
            Assert.NotNull(uri);

            var uriText = uri!.ToString();
            Assert.Contains("/library/sections/4/all", uriText);
            Assert.Contains("type=18", uriText);
            Assert.Contains("id=14343", uriText);
            Assert.Contains("summary.value=", uriText);
            Assert.Contains("summary.locked=1", uriText);
        }

        [Fact]
        public void ToPutRequestInformation_WithNegativeSectionId_Throws()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                client.Library.Collections[14343].ToPutRequestInformation(-1, requestConfiguration =>
                {
                    requestConfiguration.QueryParameters.TypeId = 18;
                }));
        }
    }
}
