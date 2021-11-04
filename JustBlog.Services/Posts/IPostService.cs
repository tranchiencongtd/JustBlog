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

        PostDetailViewModel GetPostByYearMonthUrlSlug(int year, int month, string urlSlug);

        IEnumerable<PostViewModel> GetPostsByCategoryUrlSlug(string slugUrl);

        ResponseResult Create(CreatePostViewModel request);

        ResponseResult Delete(int Id);
    }
}
