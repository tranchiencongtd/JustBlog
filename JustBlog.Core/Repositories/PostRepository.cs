using JustBlog.Core.Infrastructures;
using JustBlog.Core.IRepositories;
using JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {

        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            var result = this.context.Posts.Where(p =>  p.CreatedOn.Year == year 
                                                && p.CreatedOn.Month == month
                                                && p.UrlSlug == urlSlug)
                                                    .FirstOrDefault();
            return result;
        }

        public IList<Post> GetPostsByCategoryUrlSlug(string urlSlug)
        {
            var results = this.context.Posts.Where(p => p.Category.UrlSlug == urlSlug).ToList();
            return results;
        }
    }
}
