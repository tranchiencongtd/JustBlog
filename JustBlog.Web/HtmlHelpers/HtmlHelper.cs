using JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JustBlog.Web.HtmlHelpers
{
    public static class HtmlHelperCustom
    {
        public static IHtmlString TagLink(this HtmlHelper helper, IList<TagViewModel> tags)
        {
            var html = $"<div class={"mt-5"}>";

            var css = new string[] {
                                    "badge bg-primary ml-2 p-2 badge-pill text-white",
                                    "badge bg-success ml-2 p-2 badge-pill text-white",
                                    "badge bg-warning ml-2 p-2 badge-pill text-white",
                                    "badge bg-danger ml-2 p-2 badge-pill text-white",
                                    "badge bg-info ml-2 p-2 badge-pill text-white",
                                    "badge bg-dark ml-2 p-2 badge-pill text-white",
                                    };
            int count = 0;
            foreach (var tag in tags)
            {
                if (count > css.Length) count = 0;
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes.Add("href", "/tag/" + tag.UrlSlug);
                tb.Attributes.Add("class", css[count]);
                tb.InnerHtml = tag.Name;
                count++;
                html += tb.ToString();
            }
            html = html + "</div>";
            return new MvcHtmlString(html);
        }

        public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "active")
        {
            ViewContext viewContext = html.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (String.IsNullOrEmpty(actions))
                actions = currentAction;

            if (String.IsNullOrEmpty(controllers))
                controllers = currentController;

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                cssClass : String.Empty;
        }
    }
}