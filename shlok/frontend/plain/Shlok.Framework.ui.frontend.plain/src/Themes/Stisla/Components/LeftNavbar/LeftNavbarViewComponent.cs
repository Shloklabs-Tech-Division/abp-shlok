using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Shlok.Framework.ui.frontend.plain.Themes.Stisla.Components.LeftNavbar
{
    public class LeftNavbarViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Stisla/Components/LeftNavbar/Default.cshtml");
        }
    }
}
