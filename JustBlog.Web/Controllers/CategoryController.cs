using JustBlog.Core;
using JustBlog.Core.Infrastructures;
using JustBlog.Services.Categories;
using JustBlog.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;

        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderMenu()
        {
            var categogies = this.categoryService.GetAll();
            return PartialView("_PartialNavbar", categogies);
        }

        public ActionResult ProductCategory(string slug)
        {
            var posts = this.postService.GetPostsByCategory(slug);
            if (posts == null)
                return HttpNotFound();
            return View(posts);
        }
    }
}
