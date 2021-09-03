using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Public.Blogs;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Public.Blogs.ClientProxies
{
    public partial class BlogPostPublicClientProxy
    {
        public virtual async Task<BlogPostPublicDto> GetAsync(string blogSlug, string blogPostSlug)
        {
            return await RequestAsync<BlogPostPublicDto>(nameof(GetAsync), blogSlug, blogPostSlug);
        }
 
        public virtual async Task<PagedResultDto<BlogPostPublicDto>> GetListAsync(string blogSlug, PagedAndSortedResultRequestDto input)
        {
            return await RequestAsync<PagedResultDto<BlogPostPublicDto>>(nameof(GetListAsync), blogSlug, input);
        }
 
    }
}
