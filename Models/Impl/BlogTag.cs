using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class BlogTag
    {
        // Primary Key
        public int ID { get; set; }
        // Foreign Keys
        public int TagID { get; set; }
        public int BlogID { get; set; }
    }
}
