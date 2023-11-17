using System.Threading.Tasks;

namespace Qa6185.Data;

public interface IQa6185DbSchemaMigrator
{
    Task MigrateAsync();
}
