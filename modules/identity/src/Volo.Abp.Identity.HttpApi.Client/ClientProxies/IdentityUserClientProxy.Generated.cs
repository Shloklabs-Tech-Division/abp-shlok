using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.Identity;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.Identity.ClientProxies
{
    public partial class IdentityUserClientProxy
    {
        public virtual async Task<IdentityUserDto> GetAsync(Guid id)
        {
            return await RequestAsync<IdentityUserDto>(nameof(GetAsync), id);
        }

        public virtual async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return await RequestAsync<PagedResultDto<IdentityUserDto>>(nameof(GetListAsync), input);
        }

        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return await RequestAsync<IdentityUserDto>(nameof(CreateAsync), input);
        }

        public virtual async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            return await RequestAsync<IdentityUserDto>(nameof(UpdateAsync), id, input);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return await RequestAsync<ListResultDto<IdentityRoleDto>>(nameof(GetRolesAsync), id);
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            return await RequestAsync<ListResultDto<IdentityRoleDto>>(nameof(GetAssignableRolesAsync));
        }

        public virtual async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            await RequestAsync(nameof(UpdateRolesAsync), id, input);
        }

        public virtual async Task<IdentityUserDto> FindByUsernameAsync(string userName)
        {
            return await RequestAsync<IdentityUserDto>(nameof(FindByUsernameAsync), userName);
        }

        public virtual async Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return await RequestAsync<IdentityUserDto>(nameof(FindByEmailAsync), email);
        }

    }
}
