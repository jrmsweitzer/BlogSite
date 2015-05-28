using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class Like
    {
        // Primary Key
        public int ID { get; set; }
        // Foreign Keys
        public int BlogID { get; set; }
        public int CommentID { get; set; }
        public int UserID { get; set; }
        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
