using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Constants
    {
        public static PermissionStrings Permissions { get { return new PermissionStrings(); } }
    }

    public class PermissionStrings
    {

        public string Admin = "Admin";
        public string RegularPoster = "Regular Poster";
        public string User = "User";
    }
}
