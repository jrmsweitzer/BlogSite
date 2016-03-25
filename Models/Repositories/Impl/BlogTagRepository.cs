using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repositories.Impl
{
    public class BlogTagRepository : BaseRepository, IBlogTagRepository
    {
        public BlogTagRepository()
        {
            _db = new BlogEntities();
        }

        public IQueryable<Tag> GetTags(int blogID)
        {
            IQueryable<int> tagIDs = 
                _db.BlogTags                           // blogtags
                    .Where(bt => bt.BlogID == blogID)  // where the blogID matches the given blogID
                    .Select(t => t.TagID);             // select the TagIDs

            return _db.Tags
                    .Where(t => tagIDs.Contains(t.ID));
        }

        public IQueryable<Blog> GetBlogs(int tagID)
        {
            IQueryable<int> blogIDs =
                _db.BlogTags
                    .Where(bt => bt.TagID == tagID)
                    .Select(b => b.BlogID);

            return _db.Blogs
                    .Where(b => blogIDs.Contains(b.ID));
        }

        public BlogTag AddBlogTag(int blogId, int tagId)
        {
            var returns = 
                _db.BlogTags.Add(new BlogTag { BlogID = blogId, TagID = tagId });
            SaveChanges();
            return returns;
        }
    }
}
