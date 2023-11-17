using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Qa6185.MyEntities
{
    public partial interface IMyEntityRepository : IRepository<MyEntity, Guid>
    {
        Task<List<MyEntity>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? property2 = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? property2 = null,
            CancellationToken cancellationToken = default);
    }
}