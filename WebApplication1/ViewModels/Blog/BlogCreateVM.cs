using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Blog
{
    public class BlogCreateVM
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public bool IsValid 
        { 
            get 
            {
                return (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Title));
            }
        }
    }
}