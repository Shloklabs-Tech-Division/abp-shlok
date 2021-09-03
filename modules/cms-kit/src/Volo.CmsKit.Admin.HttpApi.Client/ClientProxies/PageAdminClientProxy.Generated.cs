using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Admin.Pages;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Admin.Pages.ClientProxies
{
    public partial class PageAdminClientProxy
    {
        public virtual async Task<PageDto> GetAsync(Guid id)
        {
            return await RequestAsync<PageDto>(nameof(GetAsync), id);
        }
 
        public virtual async Task<PagedResultDto<PageDto>> GetListAsync(GetPagesInputDto input)
        {
            return await RequestAsync<PagedResultDto<PageDto>>(nameof(GetListAsync), input);
        }
 
        public virtual async Task<PageDto> CreateAsync(CreatePageInputDto input)
        {
            return await RequestAsync<PageDto>(nameof(CreateAsync), input);
        }
 
        public virtual async Task<PageDto> UpdateAsync(Guid id, UpdatePageInputDto input)
        {
            return await RequestAsync<PageDto>(nameof(UpdateAsync), id, input);
        }
 
        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }
 
    }
}
