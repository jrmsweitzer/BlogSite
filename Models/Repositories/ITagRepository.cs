using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetTags();
        Tag GetTag(string tagName);
        Tag AddTag(string tagName);
    }
}
