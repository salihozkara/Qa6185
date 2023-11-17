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
    public class EfCoreMyEntityRepository : EfCoreMyEntityRepositoryBase
    {
        public EfCoreMyEntityRepository(IDbContextProvider<Qa6185DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}