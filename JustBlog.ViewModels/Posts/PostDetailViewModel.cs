using JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Posts
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }


        public string Title { get; set; }


        public int ViewCount { get; set; }

        public string UrlSlug { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PostContent { get; set; }

        public List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
    }
}
