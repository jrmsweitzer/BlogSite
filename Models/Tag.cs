//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tag
    {
        public Tag()
        {
            this.BlogTags = new HashSet<BlogTag>();
        }
    
        public decimal TagID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<BlogTag> BlogTags { get; set; }
    }
}
