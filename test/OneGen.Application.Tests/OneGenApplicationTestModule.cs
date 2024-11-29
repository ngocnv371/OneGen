using Volo.Abp.Modularity;

namespace OneGen;

[DependsOn(
    typeof(OneGenApplicationModule),
    typeof(OneGenDomainTestModule)
)]
public class OneGenApplicationTestModule : AbpModule
{

}
