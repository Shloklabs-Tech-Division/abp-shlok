using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.FeatureManagement;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.FeatureManagement.ClientProxies
{
    public partial class FeaturesClientProxy
    {
        public virtual async Task<GetFeatureListResultDto> GetAsync(string providerName, string providerKey)
        {
            return await RequestAsync<GetFeatureListResultDto>(nameof(GetAsync), providerName, providerKey);
        }

        public virtual async Task UpdateAsync(string providerName, string providerKey, UpdateFeaturesDto input)
        {
            await RequestAsync(nameof(UpdateAsync), providerName, providerKey, input);
        }

    }
}
