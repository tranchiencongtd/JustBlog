using JustBlog.ViewModels.Categories;
using JustBlog.ViewModels.Posts;
using JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll();

        CategoryViewModel GetCategoryByUrlSlug(string UrlSlug);

        ResponseResult Create(CreateCategoryViewModel request);

        ResponseResult Delete(int Id);
    }
}
