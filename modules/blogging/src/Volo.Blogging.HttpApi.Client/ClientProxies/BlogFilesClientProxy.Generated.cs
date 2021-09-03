using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Blogging.Files;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.ClientProxies
{
    public partial class BlogFilesClientProxy
    {
        public virtual async Task<RawFileDto> GetAsync(string name)
        {
            return await RequestAsync<RawFileDto>(nameof(GetAsync), name);
        }

        public virtual async Task<FileUploadOutputDto> CreateAsync(FileUploadInputDto input)
        {
            return await RequestAsync<FileUploadOutputDto>(nameof(CreateAsync), input);
        }

    }
}
