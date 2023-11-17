using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Qa6185.MyEntities;

namespace Qa6185.MyEntities
{
    public class MyEntitiesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMyEntityRepository _myEntityRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MyEntitiesDataSeedContributor(IMyEntityRepository myEntityRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _myEntityRepository = myEntityRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _myEntityRepository.InsertAsync(new MyEntity
            (
                id: Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"),
                name: "fc30ceb96c6143a28232",
                property2: "50f87118"
            ));

            await _myEntityRepository.InsertAsync(new MyEntity
            (
                id: Guid.Parse("5bf3205c-4140-427f-bd85-eaa1f819e24a"),
                name: "9d21b50c99f8497a9a3ba07db2355ff44dee4ce1144940abb563210d9ae7bf1b6c",
                property2: "01a2a814648a4c00bd77ff2d"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}