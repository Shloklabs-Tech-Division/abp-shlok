using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Docs.Admin.Projects;

// ReSharper disable once CheckNamespace
namespace Volo.Docs.Admin.ClientProxies
{
    public partial class ProjectsAdminClientProxy
    {
        public virtual async Task<PagedResultDto<ProjectDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await RequestAsync<PagedResultDto<ProjectDto>>(nameof(GetListAsync), input);
        }
 
        public virtual async Task<ProjectDto> GetAsync(Guid id)
        {
            return await RequestAsync<ProjectDto>(nameof(GetAsync), id);
        }
 
        public virtual async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            return await RequestAsync<ProjectDto>(nameof(CreateAsync), input);
        }
 
        public virtual async Task<ProjectDto> UpdateAsync(Guid id, UpdateProjectDto input)
        {
            return await RequestAsync<ProjectDto>(nameof(UpdateAsync), id, input);
        }
 
        public virtual async Task DeleteAsync(Guid id)
        {
            await RequestAsync(nameof(DeleteAsync), id);
        }
 
        public virtual async Task ReindexAllAsync()
        {
            await RequestAsync(nameof(ReindexAllAsync));
        }
 
        public virtual async Task ReindexAsync(ReindexInput input)
        {
            await RequestAsync(nameof(ReindexAsync), input);
        }
 
    }
}
