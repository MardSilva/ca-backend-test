using Volo.Abp.Modularity;

namespace CA.BackendTest;

[DependsOn(
    typeof(BackendTestDomainModule),
    typeof(BackendTestTestBaseModule)
)]
public class BackendTestDomainTestModule : AbpModule
{

}
