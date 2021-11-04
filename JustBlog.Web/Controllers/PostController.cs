using JustBlog.Core;
using JustBlog.Core.Infrastructures;
using JustBlog.Core.Repositories;
using JustBlog.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int year, int month, string title)
        {
            var post = this.postService.GetPostByYearMonthUrlSlug(year, month, title);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        [ChildActionOnly]
        public ActionResult ListPosts()
        {
            var posts = this.postService.GetAll();
            if (posts == null)
               return HttpNotFound();
           return PartialView("_ListPosts", posts);
        }
    }
}