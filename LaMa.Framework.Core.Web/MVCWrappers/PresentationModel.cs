namespace LaMa.Framework.Core.Web.MVCWrappers
{
    public abstract class PresentationModel<TViewModel>
    {
        public TViewModel ViewModel { get; set; }
        public virtual void Init()
        {
            
        }
    }
}