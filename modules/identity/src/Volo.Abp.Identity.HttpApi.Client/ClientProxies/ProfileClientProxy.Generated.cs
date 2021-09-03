using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.Identity;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.Identity.ClientProxies
{
    public partial class ProfileClientProxy
    {
        public virtual async Task<ProfileDto> GetAsync()
        {
            return await RequestAsync<ProfileDto>(nameof(GetAsync));
        }

        public virtual async Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
        {
            return await RequestAsync<ProfileDto>(nameof(UpdateAsync), input);
        }

        public virtual async Task ChangePasswordAsync(ChangePasswordInput input)
        {
            await RequestAsync(nameof(ChangePasswordAsync), input);
        }

    }
}
