using AutoMapper;
using JustBlog.Core.Infrastructures;
using JustBlog.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryViewModel> GetAll()
        {
            var posts = this.unitOfWork.CategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryViewModel>>(posts);
        }
    }
}
