using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Shlok.Framework.ui.frontend.primary.Themes.ShlokFramework.Components.MainNavbar
{
    public class MainNavbarViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/ShlokFramework/Components/MainNavbar/Default.cshtml");
        }
    }
}
