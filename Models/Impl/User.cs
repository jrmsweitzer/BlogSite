using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class User
    {
        // Primary Key
        public int ID { get; set; }
        // Foreign Keys
        public UserPermission UserPermission { get; set; }
        // Data
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime JoinDate { get; set; }
        // Navigation Properties
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }

    public enum UserPermission
    {
        Admin,
        User
    }
}
