using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Qa6185.MyEntities;
using Qa6185.EntityFrameworkCore;
using Xunit;

namespace Qa6185.MyEntities
{
    public class MyEntityRepositoryTests : Qa6185EntityFrameworkCoreTestBase
    {
        private readonly IMyEntityRepository _myEntityRepository;

        public MyEntityRepositoryTests()
        {
            _myEntityRepository = GetRequiredService<IMyEntityRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myEntityRepository.GetListAsync(
                    name: "fc30ceb96c6143a28232",
                    property2: "50f87118"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myEntityRepository.GetCountAsync(
                    name: "9d21b50c99f8497a9a3ba07db2355ff44dee4ce1144940abb563210d9ae7bf1b6c",
                    property2: "01a2a814648a4c00bd77ff2d"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}