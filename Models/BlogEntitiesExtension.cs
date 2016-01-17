using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Models
{
    public partial class BlogEntities :  IBlogEntities
    {
        public void ObjectContext_OnObjectMaterialized(Object objSender, ObjectMaterializedEventArgs e)
        {
            Entry(e.Entity).State = EntityState.Detached;
        }
    }
}
