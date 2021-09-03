using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.PermissionManagement;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.PermissionManagement.ClientProxies
{
    public partial class PermissionsClientProxy
    {
        public virtual async Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey)
        {
            return await RequestAsync<GetPermissionListResultDto>(nameof(GetAsync), providerName, providerKey);
        }

        public virtual async Task UpdateAsync(string providerName, string providerKey, UpdatePermissionsDto input)
        {
            await RequestAsync(nameof(UpdateAsync), providerName, providerKey, input);
        }

    }
}
