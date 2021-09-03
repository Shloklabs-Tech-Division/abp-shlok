using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Blogging.Tagging;
using System.Collections.Generic;
using Volo.Blogging.Tagging.Dtos;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.ClientProxies
{
    public partial class TagsClientProxy
    {
        public virtual async Task<List<TagDto>> GetPopularTagsAsync(Guid blogId, GetPopularTagsInput input)
        {
            return await RequestAsync<List<TagDto>>(nameof(GetPopularTagsAsync), blogId, input);
        }

    }
}
