using Models;
using Models.Repositories;
using Models.Repositories.Impl;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public class TagService
    {
        private ITagRepository _tagRepo;

        public TagService()
        {
            _tagRepo = new TagRepository();
        }

        public List<Tag> GetTags()
        {
            return _tagRepo.GetTags();
        }

        public Tag GetTag(string tagName)
        {
            return _tagRepo.GetTag(tagName);
        }
    }
}
