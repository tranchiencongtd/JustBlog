using JustBlog.Models.Entities;
using JustBlog.ViewModels.Posts;
using JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.Posts
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetAll();

        Post FindPost(int year, int month, string urlSlug);

        IEnumerable<PostViewModel> GetPostsByCategory(string slug);
    }
}
