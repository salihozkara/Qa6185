using Qa6185.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Qa6185.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Qa6185EntityFrameworkCoreModule),
    typeof(Qa6185ApplicationContractsModule)
)]
public class Qa6185DbMigratorModule : AbpModule
{
}
