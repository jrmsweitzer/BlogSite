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

        public UserService(IBlogEntities db)
        {
            _userRepo = new UserRepository(db);
        }

        public UserService()
        {
            var db = new BlogEntities();
            _userRepo = new UserRepository(db);
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
