using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Shlok.Framework.ui.frontend.plain.Menus
{
    public class StislaMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
