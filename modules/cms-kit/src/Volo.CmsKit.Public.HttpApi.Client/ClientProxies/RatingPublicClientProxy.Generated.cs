using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.CmsKit.Public.Ratings;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Public.Ratings.ClientProxies
{
    public partial class RatingPublicClientProxy
    {
        public virtual async Task<RatingDto> CreateAsync(string entityType, string entityId, CreateUpdateRatingInput input)
        {
            return await RequestAsync<RatingDto>(nameof(CreateAsync), entityType, entityId, input);
        }
 
        public virtual async Task DeleteAsync(string entityType, string entityId)
        {
            await RequestAsync(nameof(DeleteAsync), entityType, entityId);
        }
 
        public virtual async Task<List<RatingWithStarCountDto>> GetGroupedStarCountsAsync(string entityType, string entityId)
        {
            return await RequestAsync<List<RatingWithStarCountDto>>(nameof(GetGroupedStarCountsAsync), entityType, entityId);
        }
 
    }
}
