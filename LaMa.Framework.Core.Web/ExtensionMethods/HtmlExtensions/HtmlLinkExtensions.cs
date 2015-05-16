using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using LaMa.Framework.Core.Web.Enums;
using LaMa.Framework.Core.Web.ExtensionMethods.DictionaryExtensions;
using LaMa.Framework.Core.Web.ValueObjects;

namespace LaMa.Framework.Core.Web.ExtensionMethods.HtmlExtensions
{
    public static class HtmlLinkExtensions
    {

      

        public static MvcHtmlString ActionLinkForNavigation(this HtmlHelper html, string linkText, string action,
                                                            string controller, object routeValues=null, object htmlAttributes=null,
                                                            MatchesRoutingPart matchesRoutingPart = MatchesRoutingPart.All)
        {
            ViewContext viewContext = GetViewContext(html);
            RouteValueDictionary routeValuesDictionary = viewContext.RouteData.Values;
            var areaValue = GetAreaValue(htmlAttributes);

            var routeOfActionLink = new RouteInfo
            {
                Action = action,
                Controller = controller,
                Area = areaValue,
            };
            var currentRoute = new RouteInfo
            {
                Action = routeValuesDictionary["action"].ToString(),
                Controller = routeValuesDictionary["controller"].ToString(),
                Area = routeValuesDictionary.GetValueOrDefault("area", string.Empty).ToString(),
            };
            var tagBuilder = new TagBuilder("li");
            if (currentRoute.IsEqualTo(routeOfActionLink, matchesRoutingPart))
            {
                tagBuilder.AddCssClass("active");
            }

            var actionLink = html.ActionLink(linkText, action, controller, routeValues, htmlAttributes);
            tagBuilder.InnerHtml = actionLink.ToString();

            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        private static string GetAreaValue(object htmlAttributes)
        {
            if (htmlAttributes ==null)
            {
                return string.Empty;
            }
            string areaValue = string.Empty;


            var typeValue = htmlAttributes.GetType();
            var propertyInfo = typeValue.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(x => x.GetMethod != null && x.Name.ToLower() == "area" && x.GetIndexParameters().Length == 0);

            if (propertyInfo != null)
            {
                areaValue = propertyInfo.GetValue(htmlAttributes).ToString();
            }
            return areaValue;
        }


        private static ViewContext GetViewContext(HtmlHelper html)
        {
            ViewContext viewContext = html.ViewContext;

            if (viewContext.Controller.ControllerContext.IsChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;

            return viewContext;
        }
    }
}