using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Admin.Menus;
using Volo.CmsKit.Menus;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Admin.Menus.ClientProxies
{
    public partial class MenuItemAdminClientProxy
    {
        public virtual async Task<ListResultDto<MenuItemDto>> GetListAsync()
        {
            return await RequestAsync<ListResultDto<MenuItemDto>>(nameof(GetListAsync));
        }
 
        public virtual async Task<MenuItemDto> GetAsync(Guid id)
        {
            return await RequestAsync<MenuItemDto>(nameof(GetAsync), id);
        }
 
        public virtual async Task<MenuItemDto> CreateAsync(MenuItemCreateInput input)
        {
            return await RequestAsync<MenuItemDto>(nameof(CreateAsync), input);
        }
 
        public virtual async Task<MenuItemDto> UpdateAsync(Guid id, MenuItemUpdateInput input)
        {
            return await RequestAsync<MenuItemDto>(nameof(UpdateAsync), id, input);
        }
 
        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }
 
        public virtual async Task MoveMenuItemAsync(Guid id, MenuItemMoveInput input)
        {
            await RequestAsync(nameof(MoveMenuItemAsync), id, input);
        }
 
        public virtual async Task<PagedResultDto<PageLookupDto>> GetPageLookupAsync(PageLookupInputDto input)
        {
            return await RequestAsync<PagedResultDto<PageLookupDto>>(nameof(GetPageLookupAsync), input);
        }
 
    }
}
