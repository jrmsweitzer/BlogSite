using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEntity
    {
        int ID { get; set; }
        void Insert();
        void Update();
        List<IEntity> Load();
    }
}
