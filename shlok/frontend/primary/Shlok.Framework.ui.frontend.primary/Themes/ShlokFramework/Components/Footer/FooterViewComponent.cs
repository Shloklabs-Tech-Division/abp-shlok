using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Shlok.Framework.ui.frontend.primary.Themes.ShlokFramework.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/ShlokFramework/Components/Footer/Default.cshtml");
        }
    }
}