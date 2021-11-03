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
        public int CountPostsForCategory(string category)
        {
            var results = context.Posts.Where(p => p.Category.Name == category).ToList();
            return results.Count();
        }

        public int CountPostsForTag(string tag)
        {
            var results = context.Posts.Where(p => p.Tags.Any(t => t.Name == tag)).ToList();
            return results.Count();
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            var result = context.Posts.Where(p =>  p.PostedOn.Year == year 
                                                && p.PostedOn.Month == month
                                                && p.UrlSlug == urlSlug)
                                                    .FirstOrDefault();
            return result;
        }

        public IList<Post> GetLatestPost(int size)
        {
            var results = context.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
            return results;
        }

        public IList<Post> GetPostsByCategory(string slug)
        {
            var results = context.Posts.Where(p => p.Category.UrlSlug == slug).ToList();
            return results;
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            var result = context.Posts.Where(p => p.PostedOn == monthYear).ToList();
            return result;
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            var results = context.Posts.Where(p => p.Tags.Any(t => t.Name == tag)).ToList();
            return results;
        }

        public IList<Post> GetPublisedPosts()
        {
            var results = context.Posts.Where(p => p.Published).ToList();
            return results;
        }

        public IList<Post> GetUnpublisedPosts()
        {
            var results = context.Posts.Where(p => !p.Published).ToList();
            return results;
        }
    }
}
