using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Blogging.Admin.Blogs;
using Volo.Blogging.Blogs.Dtos;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.Admin.ClientProxies
{
    public partial class BlogManagementClientProxy
    {
        public virtual async Task<ListResultDto<BlogDto>> GetListAsync()
        {
            return await RequestAsync<ListResultDto<BlogDto>>(nameof(GetListAsync));
        }

        public virtual async Task<BlogDto> GetAsync(Guid id)
        {
            return await RequestAsync<BlogDto>(nameof(GetAsync), id);
        }

        public virtual async Task<BlogDto> CreateAsync(CreateBlogDto input)
        {
            return await RequestAsync<BlogDto>(nameof(CreateAsync), input);
        }

        public virtual async Task<BlogDto> UpdateAsync(Guid id, UpdateBlogDto input)
        {
            return await RequestAsync<BlogDto>(nameof(UpdateAsync), id, input);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }

        public virtual async Task ClearCacheAsync(Guid id)
        {
            await RequestAsync(nameof(ClearCacheAsync), id);
        }

    }
}
