using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Shlok.Framework.ui.frontend.primary.Bundling
{
    public class ShlokFrameworkThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/themes/shlokframework/style.css");
            context.Files.Add("/themes/shlokframework/owl-edit.css");
            context.Files.Add("/themes/shlokframework/floating-labels.css");
        }
    }
}
