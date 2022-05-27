using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentfulTest.code
{
    public class ContentfulBlogEntity
    {
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public List<string> SplitTags { get { return Tags.Split(',').Select(s => s).ToList(); } }
        public string Body { get; set; }
    }
}
