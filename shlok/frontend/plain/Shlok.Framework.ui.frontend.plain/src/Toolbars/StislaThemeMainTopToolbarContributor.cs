﻿using System.Threading.Tasks;
using Shlok.Framework.ui.frontend.plain.Themes.Stisla.Components.Toolbar.LanguageSwitch;
using Shlok.Framework.ui.frontend.plain.Themes.Stisla.Components.Toolbar.UserMenu;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Localization;
using Volo.Abp.Users;

namespace Shlok.Framework.ui.frontend.plain.Toolbars
{
    public class StislaThemeMainTopToolbarContributor : IToolbarContributor
    {
        public async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return;
            }

            if (!(context.Theme is StislaTheme))
            {
                return;
            }

            var languageProvider = context.ServiceProvider.GetService<ILanguageProvider>();

            //TODO: This duplicates GetLanguages() usage. Can we eleminate this?
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
