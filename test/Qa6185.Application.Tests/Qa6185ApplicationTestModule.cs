using Volo.Abp.Modularity;

namespace Qa6185;

[DependsOn(
    typeof(Qa6185ApplicationModule),
    typeof(Qa6185DomainTestModule)
    )]
public class Qa6185ApplicationTestModule : AbpModule
{

}
