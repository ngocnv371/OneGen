using OneGen.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OneGen.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OneGenEntityFrameworkCoreModule),
    typeof(OneGenApplicationContractsModule)
)]
public class OneGenDbMigratorModule : AbpModule
{
}
