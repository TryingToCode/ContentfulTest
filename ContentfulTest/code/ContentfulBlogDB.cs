using Contentful.Core;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ContentfulTest.code
{
    public class ContentfulBlogDB
    {
        private IConfiguration _config;
        public ContentfulBlogDB(IConfiguration config)
        {
            this._config = config;
        }

        public List<ContentfulBlogEntity> GetContentFromContentful()
        {
            var deliveryAPIKey = "Change";
            var previewAPIKey = "THESE";
            var spaceId = "VALUES";

            var httpClient = new HttpClient();
            var client = new ContentfulClient(httpClient, deliveryAPIKey, previewAPIKey, spaceId);

            var entries = client.GetEntries<ContentfulBlogEntity>().GetAwaiter().GetResult();

            return entries.ToList();
        }
    }
}
