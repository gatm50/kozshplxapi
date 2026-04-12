using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kozshplxapi.Library.Collections.Item.Posters
{
    public class PostersRequestBuilder : BaseRequestBuilder
    {
        public PostersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter)
            : base(requestAdapter, "{+baseurl}/library/collections/{collectionId}/posters", pathParameters)
        {
        }

        public PostersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter)
            : base(requestAdapter, "{+baseurl}/library/collections/{collectionId}/posters", rawUrl)
        {
        }

        public async Task PostAsync(
            byte[] image,
            Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default,
            CancellationToken cancellationToken = default)
        {
            var requestInfo = ToPostRequestInformation(image, requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }

        public RequestInformation ToPostRequestInformation(
            byte[] image,
            Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
            if (ReferenceEquals(image, null)) 
                throw new ArgumentNullException(nameof(image));

            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.SetStreamContent(new MemoryStream(image, writable: false), "image/jpeg");
            return requestInfo;
        }
    }
}
