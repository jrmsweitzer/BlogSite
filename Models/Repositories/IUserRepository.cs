using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IUserRepository : IRepository
    {
        List<User> GetUsers();

        User AddUser(User user);

        User GetUserByUserName(string username);

        User GetUserById(int id);

        User GetUserByGUID(Guid identifier);

        void ChangeUserPassword(int userId, string hashedPassword);

        User ToggleActive(int userID);
    }
}
