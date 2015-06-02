using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Repositories;

namespace Services.Impl
{
    public class UserService
    {
        private UserRepository _userRepo;

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
    }
}
