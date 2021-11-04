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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public Category GetCategoryByUrlSlug(string urlSlug)
        {
            var result = context.Categories.Where(c => c.UrlSlug == urlSlug).FirstOrDefault();
            return result;
        }
    }
}
