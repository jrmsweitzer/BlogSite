using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateDecompiler;
using Models.Repositories;
using Newtonsoft.Json;

namespace Models
{
    public partial class Blog
    {
        [Computed]
        [JsonIgnore]
        public string PostedBy
        {
            get
            {
                return User.UserName;
            }
        }
    }
}
