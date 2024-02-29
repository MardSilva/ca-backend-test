using Volo.Abp.Modularity;

namespace CA.BackendTest;

public abstract class BackendTestApplicationTestBase<TStartupModule> : BackendTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
