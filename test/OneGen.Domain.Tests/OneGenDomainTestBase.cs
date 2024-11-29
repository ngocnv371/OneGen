using Volo.Abp.Modularity;

namespace OneGen;

/* Inherit from this class for your domain layer tests. */
public abstract class OneGenDomainTestBase<TStartupModule> : OneGenTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
