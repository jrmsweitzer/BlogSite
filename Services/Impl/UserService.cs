using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Repositories;
using Models.Repositories.Impl;

namespace Services.Impl
{
    public class UserService
    {
        private IUserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public List<User> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        public User AddUser(User user)
        {
            return _userRepo.AddUser(user);
        }

        public User GetUserByUserName(string username)
        {
            return _userRepo.GetUserByUserName(username);
        }

        public User GetAnonymousUser()
        {
            return GetUserByUserName("Anonymous");
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public User GetUserByGUID(Guid identifier)
        {
            return _userRepo.GetUserByGUID(identifier);
        }

        public void ChangeUserPassword(int userId, string hashedPassword)
        {
            _userRepo.ChangeUserPassword(userId, hashedPassword);
        }
    }
}
