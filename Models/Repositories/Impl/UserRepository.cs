using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Impl
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository()
        {
            _db = new BlogEntities();
        }

        public UserRepository(IBlogEntities db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User AddUser(User user)
        {
            var u = _db.Users.Add(user);
            SaveChanges();
            return u;
        }

        public User GetUserByUserName(string username)
        {
            return _db.Users.FirstOrDefault(u => u.UserName.ToLower().Equals(username.ToLower()));
        }
    }
}
