using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseApp.Helpers
{
    public static class GlobalExtensions
    {
        public static string IsActive(this IHtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "selected" : "";
        }

        public static string  IsSelected(this IHtmlHelper html, string x, string y)
        {
            var returnActive = x == y;
            return returnActive ? "show-check" : "";
        }
    }
}
