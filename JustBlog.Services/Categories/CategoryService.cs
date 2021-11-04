using AutoMapper;
using JustBlog.Core.Infrastructures;
using JustBlog.Models.Entities;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CategoryViewModel GetCategoryByUrlSlug(string urlSlug)
        {
            var category = this.unitOfWork.CategoryRepository.GetCategoryByUrlSlug(urlSlug);
            return Mapper.Map<CategoryViewModel>(category);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public ResponseResult Create(CreateCategoryViewModel request)
        {
            try
            {
                var category = new Category()
                {
                   Name = request.Name,
                   UrlSlug = request.UrlSlug

                };
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(int Id)
        {
            try
            {
                this.unitOfWork.CategoryRepository.Delete(Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }
    }
}
