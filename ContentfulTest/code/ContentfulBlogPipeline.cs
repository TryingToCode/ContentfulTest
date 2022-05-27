using Microsoft.Extensions.Configuration;
using Statiq.Common;
using Statiq.Core;
using System;
using System.Text;

namespace ContentfulTest.code
{
    public class ContentfulBlogPipeline : Pipeline
    {
        private IConfiguration _config;

        public ContentfulBlogPipeline(IConfiguration config)
        {
            this._config = config;

            DependencyOf.Add(nameof(Statiq.Web.Pipelines.Inputs));
            DependencyOf.Add(nameof(Statiq.Web.Pipelines.Content));

            InputModules = new ModuleList{
              new ContentfulBlogModule(_config),
            };

            ProcessModules = new ModuleList {

                new SetContent(Config.FromDocument(doc => doc.GetString(nameof(ContentfulBlogEntity.Body))), MediaTypes.Markdown),

                new SetDestination(
                    Config.FromDocument(doc =>
                    new NormalizedPath($"posts/{doc[nameof(ContentfulBlogEntity.Title)]}.html").OptimizeFileName())
                )
            };

            OutputModules = new ModuleList {
              new WriteFiles()
          };
        }
    }
}
