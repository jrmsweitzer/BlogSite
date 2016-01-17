using System.Collections.Generic;
using System.Linq;

namespace AngularNancy.ViewModels
{
    public class BlogDTO
    {
        public string CreateDate { get; set; }
        public int ID { get; set; }
        public bool IsApproved { get; set; }
        public int NumShares { get; set; }
        public string Post { get; set; }
        public string PostPreview { get; set; }
        public List<TagDTO> Tags { get; set; }
        public string Title { get; set; }
        public string UserUserName { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public CategoryDTO CategoryDTO { get; set; }
    }
}
