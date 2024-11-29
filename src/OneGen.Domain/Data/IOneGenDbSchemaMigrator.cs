using System.Threading.Tasks;

namespace OneGen.Data;

public interface IOneGenDbSchemaMigrator
{
    Task MigrateAsync();
}
