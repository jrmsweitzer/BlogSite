using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class PermissionRepository
    {
        private BlogEntities _db;

        public PermissionRepository()
        {
            _db = new BlogEntities();
        }

        public Permission GetPermissionByName(string permissionName)
        {
            return _db.Permissions.FirstOrDefault(p => p.Name.Equals(permissionName));
        }
    }
}
