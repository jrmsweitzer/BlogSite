using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularNancy.ViewModels
{
    public class TagDTO
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public List<BlogDTO> Blogs { get; set; }
    }
}