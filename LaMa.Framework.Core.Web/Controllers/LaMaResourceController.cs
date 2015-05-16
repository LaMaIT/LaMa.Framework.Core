using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaMa.Framework.Core.Web.Assets;
using LaMa.Framework.Core.Web.Helpers;

namespace LaMa.Framework.Core.Web.Controllers
{
    public sealed class LaMaResourceController : LaMaController
    {
        public ActionResult GetResource(string contentName)
        {
            string extension = Path.GetExtension(contentName);
            string resourceKey = ClientFileResources.GetResource(contentName);
            if (!string.IsNullOrEmpty(resourceKey))
            {
                Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceKey);
                if (stream != null)
                {
                    return new FileStreamResult(stream, HtmlContentType.GetContentType(extension)); 
                } 
            } 
            return new HttpStatusCodeResult(404);
        }
    }
}