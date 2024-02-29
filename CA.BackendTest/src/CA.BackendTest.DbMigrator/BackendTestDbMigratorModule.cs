using CA.BackendTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CA.BackendTest.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BackendTestEntityFrameworkCoreModule),
    typeof(BackendTestApplicationContractsModule)
    )]
public class BackendTestDbMigratorModule : AbpModule
{
}
