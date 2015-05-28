using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class Tag
    {
        // Primary Key
        public int ID { get; set; }
        // Data
        public string Name { get; set; }
        // Navigation Properties
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
