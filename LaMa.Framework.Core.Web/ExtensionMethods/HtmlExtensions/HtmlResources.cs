using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using LaMa.Framework.Core.Web.Assets;
using LaMa.Framework.Core.Web.Enums;

namespace LaMa.Framework.Core.Web.ExtensionMethods.HtmlExtensions
{
    public static class HtmlResources
    {
        private static readonly string Version = "?v=" + GetVersion();

        public static MvcHtmlString LoadDefaultJavascriptFiles(this HtmlHelper html, string language = "nl",
            bool useLocalStorage = true)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            var stringBuilder = new StringBuilder();

            foreach (string javascriptName in ClientFileResources.GetDefaultScriptNames())
            {
                stringBuilder.AppendLine(html.ScriptLink("~/LaMaFrmResource/" + javascriptName));
            }
            return new MvcHtmlString(stringBuilder.ToString());
        }

        public static MvcHtmlString LoadDefaultStyleSheets(this HtmlHelper html, string language = "nl",
            bool useLocalStorage = true)
        {
            //var url = new UrlHelper(html.ViewContext.RequestContext);
            var stringBuilder = new StringBuilder();
            foreach (string stylesheetName in ClientFileResources.GetDefaultStyleSheetNames())
            {
                stringBuilder.AppendLine(html.StyleLink("~/LaMaFrmResource/" + stylesheetName));
            }
            return new MvcHtmlString(stringBuilder.ToString());
        }
         
        private static string StyleLink(this HtmlHelper html, string url)
        {
            return string.Join(string.Empty, new[]
                                             {
                                                 "<link href='",
                                                 UrlHelper.GenerateContentUrl(url, html.ViewContext.HttpContext),
                                                 Version,
                                                 "'  rel='stylesheet' type='text/css'></link>"
                                             });
        }

        private static string ScriptLink(this HtmlHelper html, string url)
        {
            return string.Join(string.Empty, new[]
                                             {
                                                 "<script src='",
                                                 UrlHelper.GenerateContentUrl(url, html.ViewContext.HttpContext),
                                                 Version,
                                                 "' type='text/javascript'></script>"
                                             });
        }

        private static string GetVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            return fvi.ProductVersion;
        }
    }
}