using System.Text;
using System.Web.Mvc;
using LaMa.Framework.Core.Web.Assets;

namespace LaMa.Framework.Core.Web.ExtensionMethods.HtmlExtensions
{
    public static class HtmlResources
    {
        private static readonly string Version = "?v=" + HtmlResources.GetVersion();
        public static MvcHtmlString LoadDefaultJavascriptFiles(this HtmlHelper html, string language = "nl", bool useLocalStorage = true)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            var stringBuilder = new StringBuilder();
     
            foreach (var javascriptName in ClientFileResources.GetDefaultScriptNames())
            { 
                stringBuilder.AppendLine(html.ScriptLink("~/LaMaFrmResource/" + javascriptName));
            } 
            return new MvcHtmlString(stringBuilder.ToString());
        }

        public static MvcHtmlString LoadDefaultStyleSheets(this HtmlHelper html, string language = "nl", bool useLocalStorage = true)
        {
            //var url = new UrlHelper(html.ViewContext.RequestContext);
            var stringBuilder = new StringBuilder();
            foreach (var stylesheetName in ClientFileResources.GetDefaultStyleSheetNames())
            {
                stringBuilder.AppendLine(html.StyleLink("~/LaMaFrmResource/" + stylesheetName));
            }
            return new MvcHtmlString(stringBuilder.ToString());
        }

        private static string StyleLink(this HtmlHelper html, string url)
        {
            return string.Join(string.Empty,new string []{
				"<link href='",
				UrlHelper.GenerateContentUrl(url, html.ViewContext.HttpContext),
				HtmlResources.Version,
				"'  rel='stylesheet' type='text/css'></link>"
			});
        }
        private static string ScriptLink(this HtmlHelper html, string url)
        { 
            return string.Join(string.Empty, new string[]
			{
				"<script src='",
				UrlHelper.GenerateContentUrl(url, html.ViewContext.HttpContext),
				HtmlResources.Version,
				"' type='text/javascript'></script>"
			});
        }
        private static string GetVersion()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(asm.Location);
            return fvi.ProductVersion;
        }
    }
}