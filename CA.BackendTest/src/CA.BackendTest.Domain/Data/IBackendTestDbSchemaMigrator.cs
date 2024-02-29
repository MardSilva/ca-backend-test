using System.Threading.Tasks;

namespace CA.BackendTest.Data;

public interface IBackendTestDbSchemaMigrator
{
    Task MigrateAsync();
}
