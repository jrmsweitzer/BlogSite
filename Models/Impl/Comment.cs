using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class Comment
    {
        // Primary Key
        public int ID { get; set; }
        // Data
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
