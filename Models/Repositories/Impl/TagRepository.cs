using System.Collections.Generic;
using System.Linq;

namespace Models.Repositories.Impl
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository()
        {
            _db = new BlogEntities();
        }

        public List<Tag> GetTags()
        {
            return _db.Tags.ToList();
        }

        public Tag GetTag(string tagName)
        {
            return _db.Tags.FirstOrDefault(t => t.Name == tagName);
        }
    }
}
