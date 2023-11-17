using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qa6185.Data;
using Volo.Abp.DependencyInjection;

namespace Qa6185.EntityFrameworkCore;

public class EntityFrameworkCoreQa6185DbSchemaMigrator
    : IQa6185DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreQa6185DbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Qa6185DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Qa6185DbContext>()
            .Database
            .MigrateAsync();
    }
}
