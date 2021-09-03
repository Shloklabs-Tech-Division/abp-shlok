using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.SettingManagement;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.SettingManagement.ClientProxies
{
    public partial class EmailSettingsClientProxy
    {
        public virtual async Task<EmailSettingsDto> GetAsync()
        {
            return await RequestAsync<EmailSettingsDto>(nameof(GetAsync));
        }

        public virtual async Task UpdateAsync(UpdateEmailSettingsDto input)
        {
            await RequestAsync(nameof(UpdateAsync), input);
        }

    }
}
