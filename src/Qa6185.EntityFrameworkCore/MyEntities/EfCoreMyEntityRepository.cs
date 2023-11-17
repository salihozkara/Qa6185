using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Qa6185.EntityFrameworkCore;

namespace Qa6185.MyEntities
{
    public abstract class EfCoreMyEntityRepositoryBase : EfCoreRepository<Qa6185DbContext, MyEntity, Guid>, IMyEntityRepository
    {
        public EfCoreMyEntityRepositoryBase(IDbContextProvider<Qa6185DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<MyEntity>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? property2 = null,
            Guid? id = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, property2, id);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MyEntityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? property2 = null,
            Guid? id = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, property2);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MyEntity> ApplyFilter(
            IQueryable<MyEntity> query,
            string? filterText = null,
            string? name = null,
            string? property2 = null,
            Guid? id = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.Property2!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(property2), e => e.Property2.Contains(property2))
                    .WhereIf(id.HasValue, e => e.Id == id);
        }
    }
}