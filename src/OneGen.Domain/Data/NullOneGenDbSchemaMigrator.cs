using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OneGen.Data;

/* This is used if database provider does't define
 * IOneGenDbSchemaMigrator implementation.
 */
public class NullOneGenDbSchemaMigrator : IOneGenDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
