using System.Threading.Tasks;
using Shlok.Framework.ui.frontend.primary.Themes.ShlokFramework.Components.Toolbar.LanguageSwitch;
using Shlok.Framework.ui.frontend.primary.Themes.ShlokFramework.Components.Toolbar.UserMenu;
using Microsoft.Extensions.DependencyInjection;
using Shlok.Framework.ui.frontend.primary.Web.Theme;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Localization;
using Volo.Abp.Users;

namespace Shlok.Framework.ui.frontend.primary.Toolbars
{
    public class ShlokFrameworkThemeMainTopToolbarContributor : IToolbarContributor
    {
        public async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return;
            }

            if (!(context.Theme is ShlokFrameworkTheme))
            {
                return;
            }

            var languageProvider = context.ServiceProvider.GetRequiredService<ILanguageProvider>();

            var languages = await languageProvider.GetLanguagesAsync();
            if (languages.Count > 1)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitchViewComponent)));
            }

            if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(UserMenuViewComponent)));
            }
        }
    }
}
