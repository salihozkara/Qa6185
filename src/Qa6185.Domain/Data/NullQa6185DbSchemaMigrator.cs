using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Qa6185.Data;

/* This is used if database provider does't define
 * IQa6185DbSchemaMigrator implementation.
 */
public class NullQa6185DbSchemaMigrator : IQa6185DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
