using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.Account;
using Volo.Abp.Identity;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.Account.ClientProxies
{
    public partial class AccountClientProxy
    {
        public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            return await RequestAsync<IdentityUserDto>(nameof(RegisterAsync), input);
        }

        public virtual async Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
        {
            await RequestAsync(nameof(SendPasswordResetCodeAsync), input);
        }

        public virtual async Task ResetPasswordAsync(ResetPasswordDto input)
        {
            await RequestAsync(nameof(ResetPasswordAsync), input);
        }

    }
}
