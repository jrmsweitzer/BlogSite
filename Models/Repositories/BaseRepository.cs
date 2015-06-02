using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class BaseRepository
    {
        protected BlogEntities _db = new BlogEntities();

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
