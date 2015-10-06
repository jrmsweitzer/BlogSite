using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Modules.Tags.Models
{
    public class BlogTag
    {
        public string Tag { get; set; }
        public int BlogId { get; set; }

        public BlogTag(string tag, int blogId)
        {
            Tag = tag;
            BlogId = blogId;
        }
    }
}