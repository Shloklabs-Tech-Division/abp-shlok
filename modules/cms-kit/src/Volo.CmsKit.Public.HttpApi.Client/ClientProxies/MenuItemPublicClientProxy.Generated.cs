using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Public.Menus;
using System.Collections.Generic;
using Volo.CmsKit.Menus;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Public.Menus.ClientProxies
{
    public partial class MenuItemPublicClientProxy
    {
        public virtual async Task<List<MenuItemDto>> GetListAsync()
        {
            return await RequestAsync<List<MenuItemDto>>(nameof(GetListAsync));
        }
 
    }
}
