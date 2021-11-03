using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JustBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Category",
              url: "Category/{slug}",
              defaults: new { controller = "Category", action = "ProductCategory" },
              namespaces: new string[] { "JustBlog.Web.Controllers" }
          );

            routes.MapRoute(
                name: "Post",
                url: "Post/{year}/{month}/{title}",
                defaults: new { controller = "Post", action = "Details" },
                constraints: new { year = @"\d{4}", month = @"\d{2}" },
                namespaces: new string[] { "JustBlog.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "JustBlog.Web.Controllers" }
            );
        }
    }
}
