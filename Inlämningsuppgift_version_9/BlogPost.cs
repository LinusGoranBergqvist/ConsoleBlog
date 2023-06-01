using Inlämningsuppgift_version_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_version_9
{
    internal class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Category> Categories { get; set; }


        //public ICollection<BlogPostCategory> Categories { get; set; }

    }
}
