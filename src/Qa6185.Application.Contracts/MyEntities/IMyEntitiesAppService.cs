using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Qa6185.Shared;

namespace Qa6185.MyEntities
{
    public partial interface IMyEntitiesAppService : IApplicationService
    {
        Task<PagedResultDto<MyEntityDto>> GetListAsync(GetMyEntitiesInput input);

        Task<MyEntityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MyEntityDto> CreateAsync(MyEntityCreateDto input);

        Task<MyEntityDto> UpdateAsync(Guid id, MyEntityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MyEntityExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}