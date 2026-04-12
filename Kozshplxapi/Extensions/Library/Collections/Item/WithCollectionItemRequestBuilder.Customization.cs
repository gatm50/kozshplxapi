using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable IDE0130
namespace Kozshplxapi.Library.Collections.Item
#pragma warning restore IDE0130
{
    public partial class WithCollectionItemRequestBuilder
    {
        /// <summary>The items property</summary>
        public global::Kozshplxapi.Library.Collections.Item.Posters.PostersRequestBuilder Posters
        {
            get => new global::Kozshplxapi.Library.Collections.Item.Posters.PostersRequestBuilder(PathParameters, RequestAdapter);
        }

        public async Task PutAsync(
            int sectionId,
            Action<RequestConfiguration<WithCollectionItemRequestBuilderPutQueryParameters>> requestConfiguration = default,
            CancellationToken cancellationToken = default)
        {
            var requestInfo = ToPutRequestInformation(sectionId, requestConfiguration);
            await RequestAdapter
                .SendNoContentAsync(requestInfo, default, cancellationToken)
                .ConfigureAwait(false);
        }

        public RequestInformation ToPutRequestInformation(
            int sectionId,
            Action<RequestConfiguration<WithCollectionItemRequestBuilderPutQueryParameters>> requestConfiguration = default)
        {
            const string urlTemplate = "{+baseurl}/library/sections/{sectionId}/all{?type*}&id={collectionId}{&title.value*}{&title.locked*}{&titleSort.value*}{&titleSort.locked*}{&summary.value*}{&summary.locked*}{&contentRating.value*}{&contentRating.locked*}";
            
            if (sectionId < 0) 
                throw new ArgumentOutOfRangeException(nameof(sectionId));

            var pathParameters = new Dictionary<string, object>(PathParameters)
            {
                ["sectionId"] = sectionId
            };

            var requestInfo = new RequestInformation(Method.PUT, urlTemplate, pathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }

        /// <summary>
        /// Modify a collection in the library
        /// </summary>
        public partial class WithCollectionItemRequestBuilderPutQueryParameters
        {
            /// <summary>The type of Collection to modify</summary>
            [QueryParameter("type")]
            public int TypeId { get; set; }

            /// <summary>Include external media metadata when modifying the collection</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("includeExternalMedia")]
            public int? IncludeExternalMedia { get; set; }
#nullable restore
#else
            [QueryParameter("includeExternalMedia")]
            public int IncludeExternalMedia { get; set; }
#endif

            /// <summary>The Summary/Description of the Collection</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("title.value")]
            public string? Title { get; set; }
#nullable restore
#else
            [QueryParameter("title.value")]
            public string Title { get; set; }
#endif

            /// <summary>Lock the summary field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("title.locked")]
            public int? TitleLocked { get; set; }
#nullable restore
#else
            [QueryParameter("title.locked")]
            public int? TitleLocked { get; set; }
#endif

            /// <summary>The Summary/Description of the Collection</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("titleSort.value")]
            public string? TitleSort { get; set; }
#nullable restore
#else
            [QueryParameter("titleSort.value")]
            public string TitleSort { get; set; }
#endif

            /// <summary>Lock the summary field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("titleSort.locked")]
            public int? TitleSortLocked { get; set; }
#nullable restore
#else
            [QueryParameter("titleSort.locked")]
            public int? TitleSortLocked { get; set; }
#endif

            /// <summary>The Summary/Description of the Collection</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("summary.value")]
            public string? Summary { get; set; }
#nullable restore
#else
            [QueryParameter("summary.value")]
            public string Summary { get; set; }
#endif

            /// <summary>Lock the summary field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("summary.locked")]
            public int? SummaryLocked { get; set; }
#nullable restore
#else
            [QueryParameter("summary.locked")]
            public int? SummaryLocked { get; set; }
#endif

            /// <summary>Lock the content rating field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("contentRating.value")]
            public string? ContentRatingValue { get; set; }
#nullable restore
#else
            [QueryParameter("contentRating.value")]
            public string ContentRatingValue { get; set; }
#endif

            /// <summary>Lock the summary field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("contentRating.locked")]
            public int? ContentRatingLocked { get; set; }
#nullable restore
#else
            [QueryParameter("contentRating.locked")]
            public int? ContentRatingLocked { get; set; }
#endif

            /// <summary>Lock the thumb field</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("thumb.locked")]
            public int? ThumbLocked { get; set; }
#nullable restore
#else
            [QueryParameter("thumb.locked")]
            public int? ThumbLocked { get; set; }
#endif
        }
    }
}
