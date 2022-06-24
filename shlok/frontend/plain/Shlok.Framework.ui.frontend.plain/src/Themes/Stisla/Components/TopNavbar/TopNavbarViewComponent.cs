using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Shlok.Framework.ui.frontend.plain.Themes.Stisla.Components.TopNavbar
{
    public class TopNavbarViewComponent : AbpViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Stisla/Components/TopNavbar/Default.cshtml");
        }
    }
}
