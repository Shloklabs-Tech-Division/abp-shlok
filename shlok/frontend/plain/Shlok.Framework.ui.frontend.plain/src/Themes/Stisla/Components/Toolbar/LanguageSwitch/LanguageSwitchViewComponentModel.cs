using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Shlok.Framework.ui.frontend.plain.Themes.Stisla.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }
    }
}
