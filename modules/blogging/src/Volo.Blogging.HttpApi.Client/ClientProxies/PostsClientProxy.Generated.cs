using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Blogging.Posts;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.ClientProxies
{
    public partial class PostsClientProxy
    {
        public virtual async Task<ListResultDto<PostWithDetailsDto>> GetListByBlogIdAndTagNameAsync(Guid blogId, string tagName)
        {
            return await RequestAsync<ListResultDto<PostWithDetailsDto>>(nameof(GetListByBlogIdAndTagNameAsync), blogId, tagName);
        }

        public virtual async Task<ListResultDto<PostWithDetailsDto>> GetTimeOrderedListAsync(Guid blogId)
        {
            return await RequestAsync<ListResultDto<PostWithDetailsDto>>(nameof(GetTimeOrderedListAsync), blogId);
        }

        public virtual async Task<PostWithDetailsDto> GetForReadingAsync(GetPostInput input)
        {
            return await RequestAsync<PostWithDetailsDto>(nameof(GetForReadingAsync), input);
        }

        public virtual async Task<PostWithDetailsDto> GetAsync(Guid id)
        {
            return await RequestAsync<PostWithDetailsDto>(nameof(GetAsync), id);
        }

        public virtual async Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            return await RequestAsync<PostWithDetailsDto>(nameof(CreateAsync), input);
        }

        public virtual async Task<PostWithDetailsDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            return await RequestAsync<PostWithDetailsDto>(nameof(UpdateAsync), id, input);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }

    }
}
