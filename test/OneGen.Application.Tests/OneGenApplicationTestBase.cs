using Volo.Abp.Modularity;

namespace OneGen;

public abstract class OneGenApplicationTestBase<TStartupModule> : OneGenTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
