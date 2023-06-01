using Inlämningsuppgift_version_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_version_9
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        //public ICollection<BlogPostCategory> BlogPosts { get; set; }
    }
}
