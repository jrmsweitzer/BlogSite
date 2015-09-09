using Repository.DataAccess;
using Repository.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public partial class Blog : IEntity
    {
        public void Insert()
        {
            var obj = new BlogDataAccess();
            obj.InsertBlog();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public List<IEntity> Load()
        {
            throw new NotImplementedException();
        }
    }
}
