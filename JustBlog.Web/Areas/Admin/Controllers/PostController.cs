using JustBlog.Services.Categories;
using JustBlog.Services.Posts;
using JustBlog.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Web.Areas.Admin.Controllers
{

    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        // GET: Admin/Post
        public ActionResult Index()
        {
            var posts = this.postService.GetAll();
            if (posts == null)
                return HttpNotFound();
            return View(posts);
        }

        public ActionResult Create()
        {
            var categories = this.categoryService.GetAll();

            TempData["Categories"] = categories;
            return View();
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CreatePostViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categories = this.categoryService.GetAll();

                TempData["Categories"] = categories;

                return View(request);
            }

            var response = this.postService.Create(request);
            if (response.IsSuccessed)
            {
                //return RedirectToAction(nameof(Index));
                return Redirect("/admin/post");
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }

        public ActionResult Delete(int id)
        {
            var response = this.postService.Delete(id);
            if (response.IsSuccessed)
            {
                return Redirect("/admin/post");
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View();
        }
    }
}