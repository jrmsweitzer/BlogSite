using Models;
using Models.Repositories;
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
            _permissionRepo = new PermissionRepository();
        }

        public Permission GetPermissionByName(string name)
        {
            return _permissionRepo.GetPermissionByName(name);
        }
    }
}
