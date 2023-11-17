using Qa6185.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Qa6185;

[DependsOn(
    typeof(Qa6185EntityFrameworkCoreTestModule)
    )]
public class Qa6185DomainTestModule : AbpModule
{

}
