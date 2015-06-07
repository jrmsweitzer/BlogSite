using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class BlogEntities : IBlogEntities
    {
        public void ObjectContext_OnObjectMaterialized(Object objSender, ObjectMaterializedEventArgs e)
        {
            Entry(e.Entity).State = EntityState.Detached;
        }
    }
}
