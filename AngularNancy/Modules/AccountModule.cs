using AngularNancy.ViewModels;
using Models;
using Nancy;
using Nancy.ModelBinding;
using Services.Impl;
using Utilities;

namespace AngularNancy.Modules
{
    public class AccountModule : NancyModule
    {
        UserService userSvc;
        EncryptionService encryptionSvc;
        public AccountModule()
        {
            userSvc = new UserService();
            encryptionSvc = new EncryptionService();

            Post["/api/v1/account/register"] = _ =>
            {
                var vm = this.Bind<LoginDTO>();
                if (userSvc.GetUserByUserName(vm.Username) == null)
                {
                    var user = new User(
                        vm.Username, 
                        encryptionSvc.CreateHash(vm.Password), 
                        Constants.PermissionIDs.User);
                    userSvc.AddUser(user);
                    // Fix redirect.
                    return AutoMapper.Mapper.DynamicMap<UserDTO>(user);
                }
                // Should return error.
                return vm;
            };

            Post["/api/v1/account/login"] = _ =>
            {
                var vm = this.Bind<LoginDTO>();
                var user = userSvc.GetUserByUserName(vm.Username);

                if (user != null && 
                    encryptionSvc.ValidatePassword(
                        vm.Password, user.HashedPassword))
                {
                    // DO LOGIN STUFF HERE.
                    return AutoMapper.Mapper.DynamicMap<UserDTO>(user);
                }

                return vm;
            };

            Post["/api/v1/account/changePassword"] = _ =>
            {
                var vm = this.Bind<PasswordDTO>();

                return null;
            };
        }
    }
}