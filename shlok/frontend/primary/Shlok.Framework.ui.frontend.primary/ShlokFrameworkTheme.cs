using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Shlok.Framework.ui.frontend.primary.Web.Theme
{
    [ThemeName(Name)]
    public class ShlokFrameworkTheme : ITheme, ITransientDependency
    {
        public const string Name = "ShlokFramework";

        public virtual string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/ShlokFramework/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/ShlokFramework/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/ShlokFramework/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/ShlokFramework/Layouts/Application.cshtml" : null;
            }
        }
    }
}
