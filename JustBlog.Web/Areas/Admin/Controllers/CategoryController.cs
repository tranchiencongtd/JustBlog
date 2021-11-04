using JustBlog.Services.Categories;
using JustBlog.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;

        public CategoryController( ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            if (categories == null)
                return HttpNotFound();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = this.categoryService.Create(request);
            if (response.IsSuccessed)
            {
                return Redirect("/admin/category");
            }

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }

        public ActionResult Delete(int id)
        {
            var response = this.categoryService.Delete(id);
            if (response.IsSuccessed)
            {
                return Redirect("/admin/category");
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View();
        }
    }
}