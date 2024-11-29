using Volo.Abp.Modularity;

namespace OneGen;

[DependsOn(
    typeof(OneGenDomainModule),
    typeof(OneGenTestBaseModule)
)]
public class OneGenDomainTestModule : AbpModule
{

}
