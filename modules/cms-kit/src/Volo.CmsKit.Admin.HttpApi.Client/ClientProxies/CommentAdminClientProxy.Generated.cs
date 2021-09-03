using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Admin.Comments;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Admin.Comments.ClientProxies
{
    public partial class CommentAdminClientProxy
    {
        public virtual async Task<PagedResultDto<CommentWithAuthorDto>> GetListAsync(CommentGetListInput input)
        {
            return await RequestAsync<PagedResultDto<CommentWithAuthorDto>>(nameof(GetListAsync), input);
        }
 
        public virtual async Task<CommentWithAuthorDto> GetAsync(Guid id)
        {
            return await RequestAsync<CommentWithAuthorDto>(nameof(GetAsync), id);
        }
 
        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }
 
    }
}
