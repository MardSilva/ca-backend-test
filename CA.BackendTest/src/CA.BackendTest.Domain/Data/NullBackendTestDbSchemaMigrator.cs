using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CA.BackendTest.Data;

/* This is used if database provider does't define
 * IBackendTestDbSchemaMigrator implementation.
 */
public class NullBackendTestDbSchemaMigrator : IBackendTestDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
