using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Docs.Projects;
using Volo.Docs.Documents;

// ReSharper disable once CheckNamespace
namespace Volo.Docs.Projects.ClientProxies
{
    public partial class DocsProjectClientProxy
    {
        public virtual async Task<ListResultDto<ProjectDto>> GetListAsync()
        {
            return await RequestAsync<ListResultDto<ProjectDto>>(nameof(GetListAsync));
        }
 
        public virtual async Task<ProjectDto> GetAsync(string shortName)
        {
            return await RequestAsync<ProjectDto>(nameof(GetAsync), shortName);
        }
 
        public virtual async Task<string> GetDefaultLanguageCodeAsync(string shortName, string version)
        {
            return await RequestAsync<string>(nameof(GetDefaultLanguageCodeAsync), shortName, version);
        }
 
        public virtual async Task<ListResultDto<VersionInfoDto>> GetVersionsAsync(string shortName)
        {
            return await RequestAsync<ListResultDto<VersionInfoDto>>(nameof(GetVersionsAsync), shortName);
        }
 
        public virtual async Task<LanguageConfig> GetLanguageListAsync(string shortName, string version)
        {
            return await RequestAsync<LanguageConfig>(nameof(GetLanguageListAsync), shortName, version);
        }
 
    }
}
