using Volo.Abp.Modularity;

namespace CA.BackendTest;

/* Inherit from this class for your domain layer tests. */
public abstract class BackendTestDomainTestBase<TStartupModule> : BackendTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
