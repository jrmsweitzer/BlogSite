using AngularNancy.ViewModels;
using Models;
using Nancy;
using Services.Impl;
using System.Collections.Generic;
using System.Linq;

namespace AngularNancy.Modules
{
    public class UsersModule : NancyModule
    {
        private UserService userService;
        private PermissionService permissionService;

        public UsersModule()
        {
            userService = new UserService();
            permissionService = new PermissionService();

            Get["/api/v1/users/"] = _ =>
            {
                List<User> listUsers = userService.GetUsers();

                var results =
                    listUsers.Select(u => AutoMapper.Mapper.DynamicMap<UserDTO>(u));

                List<UserDTO> returns = new List<UserDTO>();
                List<Permission> permissions = permissionService.GetPermissions();

                foreach (var user in results)
                {
                    user.Permission =
                        AutoMapper.Mapper.DynamicMap<PermissionDTO>(
                            permissions.FirstOrDefault(p => p.ID == user.PermissionID));

                    returns.Add(user);
                }

                return returns;
            };

            Get["/api/v1/user/{userName}"] = _ =>
            {
                User user = userService.GetUserByUserName(_.userName);
                UserDTO userDTO = AutoMapper.Mapper.DynamicMap<UserDTO>(user);
                List<Permission> permissions = permissionService.GetPermissions();

                userDTO.Permission =
                    AutoMapper.Mapper.DynamicMap<PermissionDTO>(
                        permissions.FirstOrDefault(p => p.ID == user.PermissionID));
                return userDTO;
            };

            Post["/api/v1/user/toggleActive/{userID}"] = _ =>
            {
                return userService.ToggleActive(_.userID);
            };
        }
    }
}