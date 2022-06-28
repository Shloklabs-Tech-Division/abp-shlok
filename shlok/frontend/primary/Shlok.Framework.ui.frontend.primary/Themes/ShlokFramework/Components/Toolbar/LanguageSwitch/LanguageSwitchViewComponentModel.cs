using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Shlok.Framework.ui.frontend.primary.Themes.ShlokFramework.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }
    }
}