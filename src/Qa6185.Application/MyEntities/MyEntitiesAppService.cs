using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Qa6185.Permissions;
using Qa6185.MyEntities;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Qa6185.Shared;

namespace Qa6185.MyEntities
{

    [Authorize(Qa6185Permissions.MyEntities.Default)]
    public abstract class MyEntitiesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MyEntityExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IMyEntityRepository _myEntityRepository;
        protected MyEntityManager _myEntityManager;

        public MyEntitiesAppServiceBase(IMyEntityRepository myEntityRepository, MyEntityManager myEntityManager, IDistributedCache<MyEntityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _myEntityRepository = myEntityRepository;
            _myEntityManager = myEntityManager;
        }

        public virtual async Task<PagedResultDto<MyEntityDto>> GetListAsync(GetMyEntitiesInput input)
        {
            var totalCount = await _myEntityRepository.GetCountAsync(input.FilterText, input.Name, input.Property2, input.Id);
            var items = await _myEntityRepository.GetListAsync(input.FilterText, input.Name, input.Property2, input.Id, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MyEntityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MyEntity>, List<MyEntityDto>>(items)
            };
        }

        public virtual async Task<MyEntityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<MyEntity, MyEntityDto>(await _myEntityRepository.GetAsync(id));
        }

        [Authorize(Qa6185Permissions.MyEntities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _myEntityRepository.DeleteAsync(id);
        }

        [Authorize(Qa6185Permissions.MyEntities.Create)]
        public virtual async Task<MyEntityDto> CreateAsync(MyEntityCreateDto input)
        {

            var myEntity = await _myEntityManager.CreateAsync(
            input.Name, input.Property2
            );

            return ObjectMapper.Map<MyEntity, MyEntityDto>(myEntity);
        }

        [Authorize(Qa6185Permissions.MyEntities.Edit)]
        public virtual async Task<MyEntityDto> UpdateAsync(Guid id, MyEntityUpdateDto input)
        {

            var myEntity = await _myEntityManager.UpdateAsync(
            id,
            input.Name, input.Property2, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MyEntity, MyEntityDto>(myEntity);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MyEntityExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _myEntityRepository.GetListAsync(input.FilterText, input.Name, input.Property2);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MyEntity>, List<MyEntityExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MyEntities.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MyEntityExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}