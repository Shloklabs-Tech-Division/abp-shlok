using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Tags;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Public.Tags.ClientProxies
{
    public partial class TagPublicClientProxy
    {
        public virtual async Task<List<TagDto>> GetAllRelatedTagsAsync(string entityType, string entityId)
        {
            return await RequestAsync<List<TagDto>>(nameof(GetAllRelatedTagsAsync), entityType, entityId);
        }
 
    }
}
