using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Qa6185.MyEntities
{
    public class MyEntitiesAppServiceTests : Qa6185ApplicationTestBase
    {
        private readonly IMyEntitiesAppService _myEntitiesAppService;
        private readonly IRepository<MyEntity, Guid> _myEntityRepository;

        public MyEntitiesAppServiceTests()
        {
            _myEntitiesAppService = GetRequiredService<IMyEntitiesAppService>();
            _myEntityRepository = GetRequiredService<IRepository<MyEntity, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _myEntitiesAppService.GetListAsync(new GetMyEntitiesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("5bf3205c-4140-427f-bd85-eaa1f819e24a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _myEntitiesAppService.GetAsync(Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MyEntityCreateDto
            {
                Name = "2d675c72886d4fb3a712a0c028e3c9",
                Property2 = "9af4879250f643f98062ba9b30f9db099b56fc13dd394fd0aede0f7796d6e0f9401ba3f05eed40f29a7a60c"
            };

            // Act
            var serviceResult = await _myEntitiesAppService.CreateAsync(input);

            // Assert
            var result = await _myEntityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("2d675c72886d4fb3a712a0c028e3c9");
            result.Property2.ShouldBe("9af4879250f643f98062ba9b30f9db099b56fc13dd394fd0aede0f7796d6e0f9401ba3f05eed40f29a7a60c");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MyEntityUpdateDto()
            {
                Name = "400d54e3911a471ca2d4114a37c5fe7d148747b597054a3e8eaf6199e1985cb05b2c20a002614020982a0eb33f6e",
                Property2 = "d8cc34c860734642be8d49d62168d5d972d7c2d8733a49b9b0fb9ab13d8eb12"
            };

            // Act
            var serviceResult = await _myEntitiesAppService.UpdateAsync(Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"), input);

            // Assert
            var result = await _myEntityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("400d54e3911a471ca2d4114a37c5fe7d148747b597054a3e8eaf6199e1985cb05b2c20a002614020982a0eb33f6e");
            result.Property2.ShouldBe("d8cc34c860734642be8d49d62168d5d972d7c2d8733a49b9b0fb9ab13d8eb12");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _myEntitiesAppService.DeleteAsync(Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"));

            // Assert
            var result = await _myEntityRepository.FindAsync(c => c.Id == Guid.Parse("53b236b6-67e7-4b9d-bf0a-1b87edb15db4"));

            result.ShouldBeNull();
        }
    }
}