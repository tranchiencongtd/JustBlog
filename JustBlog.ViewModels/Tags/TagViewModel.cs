using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Tags
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }
    }
}
