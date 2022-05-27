using Microsoft.Extensions.Configuration;
using Statiq.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentfulTest.code
{
    public class ContentfulBlogModule : Module
    {
        private IConfiguration _config;
        public ContentfulBlogModule(IConfiguration config)
        {
            this._config = config;
        }

        protected override async Task<IEnumerable<IDocument>> ExecuteContextAsync(IExecutionContext context)
        {
            var data = new ContentfulBlogDB(_config).GetContentFromContentful();

            List<IDocument> outputs = new List<IDocument>();

            foreach (var item in data)
            {
                var StringObject = new Dictionary<string, object>();
                StringObject.Add(nameof(item.Title), item.Title);
                StringObject.Add(nameof(item.Published), item.Published);
                StringObject.Add(nameof(item.Author), item.Author);
                StringObject.Add(nameof(item.Body), item.Body);
                //StringObject.Add("Tags", item.SplitTags);
                StringObject.Add("IsPost", true);

                var doc = context.CreateDocument(item.Title, StringObject, item.Body);

                outputs.Add(doc);
            }

            return outputs;
        }
    }
}
