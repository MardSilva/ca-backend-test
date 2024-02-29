using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CA.BackendTest.Data;
using Volo.Abp.DependencyInjection;

namespace CA.BackendTest.EntityFrameworkCore;

public class EntityFrameworkCoreBackendTestDbSchemaMigrator
    : IBackendTestDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBackendTestDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BackendTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BackendTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
