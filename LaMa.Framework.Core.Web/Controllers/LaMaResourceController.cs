using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaMa.Framework.Core.Web.Assets;
using LaMa.Framework.Core.Web.Models;

namespace LaMa.Framework.Core.Web.Controllers
{
    public class LaMaResourceController : LaMaController
    {
        public ActionResult GetResource(string contentName)
        {
            string extension = Path.GetExtension(contentName);
            string resourceKey = ClientFileResources.GetResource(contentName);
            Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceKey);

            if (stream == null)
            {
                //moet resource worden
                return new HttpStatusCodeResult(404);
            }
            var result = new FileStreamResult(stream, HtmlContentType.GetContentType(extension));

            return result;
        }
    }
}