using System.Web.Mvc;

namespace LaMa.Framework.Core.Web.MVCWrappers
{
    public abstract class WebViewPage<TPresentationModel, TViewModel> : WebViewPage<TViewModel> where TPresentationModel : PresentationModel<TViewModel>, new()
    {
        public TPresentationModel PresentationModel { get; set; }
      

        public override void InitHelpers()
        {
            base.InitHelpers();
            PresentationModel = new TPresentationModel();
            PresentationModel.ViewModel = this.Model;
            PresentationModel.Init();
           
        }
    }
}