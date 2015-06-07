using Models;
using Models.Repositories;
using Models.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PermissionService
    {
        PermissionRepository _permissionRepo;

        public PermissionService()
        {
            var context = new BlogEntities();
            _permissionRepo = new PermissionRepository(context);
        }

        public Permission GetPermissionByName(string name)
        {
            return _permissionRepo.GetPermissionByName(name);
        }
    }
}
