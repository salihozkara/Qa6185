using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityManagerBase : DomainService
    {
        protected IMyEntityRepository _myEntityRepository;

        public MyEntityManagerBase(IMyEntityRepository myEntityRepository)
        {
            _myEntityRepository = myEntityRepository;
        }

        public virtual async Task<MyEntity> CreateAsync(
        string? name = null, string? property2 = null)
        {

            var myEntity = new MyEntity(
             GuidGenerator.Create(),
             name, property2
             );

            return await _myEntityRepository.InsertAsync(myEntity);
        }

        public virtual async Task<MyEntity> UpdateAsync(
            Guid id,
            string? name = null, string? property2 = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var myEntity = await _myEntityRepository.GetAsync(id);

            myEntity.Name = name;
            myEntity.Property2 = property2;

            myEntity.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _myEntityRepository.UpdateAsync(myEntity);
        }

    }
}