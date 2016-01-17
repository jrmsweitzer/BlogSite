using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Impl
{
    public class PermissionRepository : BaseRepository, IPermissionRepository
    {
        public PermissionRepository()
        {
            _db = new BlogEntities();
        }

        public PermissionRepository(IBlogEntities db)
        {
            _db = db;
        }

        public Permission GetPermissionByName(string permissionName)
        {
            return _db.Permissions.FirstOrDefault(p => p.Name.Equals(permissionName));
        }

        public List<Permission> GetPermissions()
        {
            return _db.Permissions.ToList();
        }
    }
}
