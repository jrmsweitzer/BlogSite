using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularNancy.ViewModels
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public int ID { get; set; }
        public PermissionDTO Permission { get; set; }
        public int PermissionID { get; set; }
        public string JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}